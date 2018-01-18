using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoniumMoney : MonoBehaviour {

    /// <summary>
    /// Le texte affichant le nombre de protonium
    /// </summary>
    public Text protoText;

    /// <summary>
    /// Le nombre de protonium
    /// </summary>
    public int money = 0;

	// Use this for initialization
	void Start () {
        money = PlayerPrefs.GetInt("Protonium");
        protoText.text = PlayerPrefs.GetInt("Protonium").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Sauvegarde la money 
    /// </summary>
    /// <param name="newValue"> La nouvelle valeur</param>
    public void SaveProtoniumMoney(int newValue)
    {
        PlayerPrefs.SetInt("Protonium", newValue);
    }
}
