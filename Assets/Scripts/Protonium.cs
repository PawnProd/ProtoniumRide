using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de tester la collision avec le joueur
/// </summary>
public class Protonium : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().NbProtonium += 1;
            Destroy(gameObject);
        }
    }
}
