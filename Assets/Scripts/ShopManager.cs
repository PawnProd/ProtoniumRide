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
    /// La page actuelle
    /// </summary>
    private int currentPage;


    private void Start()
    {
        LoadShopModule();
        currentPage = 0;
    }

    public void LoadShopModule()
    {
        int nbModule = 0;
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
            }
        }
    }

    public GameObject CreatePanelAchat()
    {
        GameObject newPanel = new GameObject("Panel_Achat", typeof(RectTransform), typeof(VerticalLayoutGroup));

        newPanel.layer = 5;

        // On setup le rectTransform
        RectTransform rectTransform = newPanel.GetComponent<RectTransform>();
        rectTransform.SetParent(modulePanel.transform);
        rectTransform.localPosition = new Vector3(0, -124, 0);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 948.2f);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1424.8f);



        // On setup le layout vertical group
        VerticalLayoutGroup newPanelLayout = newPanel.GetComponent<VerticalLayoutGroup>();
        newPanelLayout.padding = new RectOffset(0, 0, 25, 25);
        newPanelLayout.spacing = 25;
        newPanelLayout.childAlignment = TextAnchor.UpperCenter;
        newPanelLayout.childControlWidth = false;
        newPanelLayout.childControlHeight = true;
        newPanelLayout.childForceExpandWidth = false;
        newPanelLayout.childForceExpandHeight = false;

        return newPanel;
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

        modulePanel.transform.GetChild(currentPage).gameObject.SetActive(false);

        if (currentPage < modulePanel.transform.childCount - 1)
        {
            ++currentPage;
            if(currentPage == modulePanel.transform.childCount - 1)
            {
                downArrow.SetActive(false);
            }

            modulePanel.transform.GetChild(currentPage).gameObject.SetActive(true);
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

        modulePanel.transform.GetChild(currentPage).gameObject.SetActive(false);

        if (currentPage > 0)
        {
            --currentPage;
            if (currentPage == 0)
            {
                upArrow.SetActive(false);
            }

            modulePanel.transform.GetChild(currentPage).gameObject.SetActive(true);
        }
    }
}
