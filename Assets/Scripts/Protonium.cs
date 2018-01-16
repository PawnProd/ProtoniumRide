using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
