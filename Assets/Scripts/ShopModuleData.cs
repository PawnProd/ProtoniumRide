using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopModuleData : MonoBehaviour {

    private string filePath;

    [System.Serializable]
    public struct DataShopModule
    {
        public int id;
        public GameObject module;
    }

    public List<DataShopModule> allModules;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
