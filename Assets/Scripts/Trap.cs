﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Material material = GetComponent<Renderer>().material;
            GetComponent<Renderer>().material.SetFloat("_Mode", 2);
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;
            GetComponent<Renderer>().material.SetColor("_Color", new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, 0.7f));
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
