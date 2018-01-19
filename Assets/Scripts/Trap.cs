using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gère le comportement des pièges
/// </summary>
public class Trap : MonoBehaviour {

    private GameObject cameraPlayer;

	// Use this for initialization
	void Start () {
        cameraPlayer = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
        // On test si la caméra est proche de l'objet
        if(Vector3.Distance(cameraPlayer.transform.position, transform.position) < 10)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().KillPlayer();
        }
    }
}
