using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gère le panneau d'options
/// </summary>
public class Settings : MonoBehaviour {

    /// <summary>
    /// Le slider du son
    /// </summary>
    public Slider soundSlider;

    /// <summary>
    /// Le texte affichant la valeur du volume
    /// </summary>
    public Text soundText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Update l'ensemble du volume
    /// </summary>
    public void UpdateVolume()
    {
        float soundValue = soundSlider.value;

        int soundValueInt = (int)(soundValue * 100);

        soundText.text = soundValueInt.ToString();

        AudioListener.volume = soundValue;
    }
}
