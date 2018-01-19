using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de tester les collisions entre un module et un joueur
/// </summary>
public class Module : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LevelManager.Instance.DeSpawn(gameObject);
        }
    }
}
