using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATHManager : MonoBehaviour {

    /// <summary>
    /// L'objet text concernant la distance parcourue par le joueur
    /// </summary>
    public Text distanceText;

    /// <summary>
    /// L'objet text concernant le protonium amassé par le joueur
    /// </summary>
    public Text protoniumText;

    /// <summary>
    /// Modifie la distance affiché dans l'ATH
    /// </summary>
    /// <param name="newDistance">La nouvelle distance</param>
	public void UpdateDistanceText(string newDistance)
    {
        distanceText.text = newDistance + "m";
    }

    /// <summary>
    /// Modifie le nombre de protonium affiché dans l'ATH
    /// </summary>
    /// <param name="newProtonium">Le nouveau nombre de protonium</param>
    public void UpdateProtoniumText(string newProtonium)
    {
        protoniumText.text = newProtonium;
    }
}
