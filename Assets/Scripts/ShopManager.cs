using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    /// <summary>
    /// La liste de tous les modules achetables
    /// </summary>
    public List<AchatPanel> listShopModule;

    /// <summary>
    /// Contient l'ensemble des panels d'achats concernant les modules
    /// </summary>
    public GameObject modulePanel;

    /// <summary>
    /// Le prefab d'achat
    /// </summary>
    public GameObject achatPrefab;

    /// <summary>
    /// Flèche remontant la liste des achats
    /// </summary>
    public GameObject upArrow;

    /// <summary>
    /// Flèche descendant la liste des achats
    /// </summary>
    public GameObject downArrow;

    /// <summary>
    /// Le panel de confirmation d'achat
    /// </summary>
    public GameObject panelConfirm;

    /// <summary>
    /// Le panel contenant la money
    /// </summary>
    public ProtoniumMoney protoniumMoney;

    /// <summary>
    /// La page actuelle
    /// </summary>
    private int _currentPage;

    /// <summary>
    /// L'id du module que l'on compte acheté
    /// </summary>
    private int _idModuleToBuy;



    private void Start()
    {
        LoadShopModule();
        _currentPage = 0;
    }

    /// <summary>
    /// Load l'ensemble des modules disponible à l'achat
    /// </summary>
    public void LoadShopModule()
    {
        CleanShop();
        int nbModule = 0;
        _currentPage = 0;
        GameObject newPanel = CreatePanelAchat();
        foreach (AchatPanel achat in listShopModule)
        {
            if(nbModule == 4)
            {
                if(!downArrow.activeSelf)
                {
                    downArrow.SetActive(true);
                }
                newPanel = CreatePanelAchat();
                newPanel.SetActive(false);
                nbModule = 0;
            }
            if(!achat.isBuy)
            {
                ++nbModule;
                GameObject achatModule = Instantiate(achatPrefab, newPanel.transform);
                achatModule.GetComponent<AchatDisplay>().Display(achat.objImg, achat.categorieImg, achat.objName, achat.objPrice.ToString());
                if(protoniumMoney.money >= achat.objPrice)
                {
                    achatModule.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { ShowConfirmPanel(achat); });
                }
                else
                {
                    achatModule.transform.GetChild(0).GetComponent<Button>().interactable = false;
                }
                
            }
        }
    }

    /// <summary>
    /// Supprime tous les éléments du magasin
    /// </summary>
    public void CleanShop()
    {
        foreach(Transform child in modulePanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Créer un panel Achat
    /// </summary>
    /// <returns>Le panel achat créé</returns>
    public GameObject CreatePanelAchat()
    {
        GameObject newPanel = new GameObject("Panel_Achat", typeof(RectTransform), typeof(VerticalLayoutGroup))
        {
            layer = 5
        };

        // On setup le rectTransform
        RectTransform rectTransform = newPanel.GetComponent<RectTransform>();
        rectTransform.SetParent(modulePanel.transform);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.offsetMax = new Vector2(0, 0);
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.localScale = new Vector3(1, 1, 1);



        // On setup le layout vertical group
        VerticalLayoutGroup newPanelLayout = newPanel.GetComponent<VerticalLayoutGroup>();
        newPanelLayout.padding = new RectOffset(25, 25, 25, 25);
        newPanelLayout.spacing = 25;
        newPanelLayout.childAlignment = TextAnchor.UpperCenter;
        newPanelLayout.childControlWidth = true;
        newPanelLayout.childControlHeight = true;
        newPanelLayout.childForceExpandWidth = false;
        newPanelLayout.childForceExpandHeight = false;

        return newPanel;
    }

    /// <summary>
    /// Affiche le panel de confirmation
    /// </summary>
    /// <param name="id"></param>
    public void ShowConfirmPanel(AchatPanel achat)
    {
        panelConfirm.SetActive(true);
        panelConfirm.GetComponentInChildren<Button>().onClick.AddListener(delegate () { BuyModule(achat); });
    }

    public void BuyModule(AchatPanel achat)
    {
        print("Vous venez d'acheter le module " + achat.id + " au prix de " + achat.objPrice);
        // On sauvegarde le module dans le fichier et dans la liste des modules disponibles
        StorageData.SetPath();
        StorageData.SaveModule(achat.id);

        // On soustrait à notre réserve de protonium le prix de l'objet
        int money = protoniumMoney.money - achat.objPrice;
        protoniumMoney.SaveProtoniumMoney(money);
        protoniumMoney.protoText.text = money.ToString();

        // On tag le module comme étant acheté
        int index = listShopModule.FindIndex(x => x == achat);
        listShopModule[index].isBuy = true;

        LoadShopModule();
    }

    /// <summary>
    /// Charge la page suivante du magasin
    /// </summary>
    public void Next()
    {
        if(!upArrow.activeSelf)
        {
            upArrow.SetActive(true);
        }

        modulePanel.transform.GetChild(_currentPage).gameObject.SetActive(false);

        if (_currentPage < modulePanel.transform.childCount - 1)
        {
            ++_currentPage;
            if(_currentPage == modulePanel.transform.childCount - 1)
            {
                downArrow.SetActive(false);
            }

            modulePanel.transform.GetChild(_currentPage).gameObject.SetActive(true);
        }
        
    }

    /// <summary>
    /// Charge la page précédente du magasin
    /// </summary>
    public void Prev()
    {
        if (!downArrow.activeSelf)
        {
            downArrow.SetActive(true);
        }

        modulePanel.transform.GetChild(_currentPage).gameObject.SetActive(false);

        if (_currentPage > 0)
        {
            --_currentPage;
            if (_currentPage == 0)
            {
                upArrow.SetActive(false);
            }

            modulePanel.transform.GetChild(_currentPage).gameObject.SetActive(true);
        }
    }
}
