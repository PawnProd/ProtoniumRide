using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gére le mode développeur
/// </summary>
public class AdminSystem : MonoBehaviour {

    /// <summary>
    /// Le panel admin
    /// </summary>
    public GameObject adminPanel;

    /// <summary>
    /// L'inputfield permettant d'ajouter des ressources
    /// </summary>
    public InputField ressourceField;

    /// <summary>
    /// Le panel contenant la money
    /// </summary>
    public ProtoniumMoney protoniumMoney;

    /// <summary>
    /// Le nombre de fois que l'on tape au téléphone
    /// </summary>
    private int _countTap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(MobileInput.Instance.Tap && !adminPanel.activeSelf)
        {
            print("Coucou");
            ++_countTap;
            
        }

        if(_countTap >= 7 && !adminPanel.activeSelf)
        {
            _countTap = 0;
            adminPanel.SetActive(true);
        }
	}

    /// <summary>
    /// Reset le magasin
    /// </summary>
    public void ResetShop()
    {
        StorageData.ClearFile();
        StorageData.CreateFile();
    }

    /// <summary>
    /// Reset le leaderboard
    /// </summary>
    public void ResetLeaderBoard()
    {
        Leaderboard.listScore.Clear();
        Leaderboard.ClearFile();
    }

    /// <summary>
    /// Ajoute des ressources au joueur
    /// </summary>
    public void AddRessource()
    {
        protoniumMoney.protoText.text = (int.Parse(protoniumMoney.protoText.text) + int.Parse(ressourceField.text)).ToString();
        protoniumMoney.SaveProtoniumMoney(int.Parse(protoniumMoney.protoText.text));

    }
}
