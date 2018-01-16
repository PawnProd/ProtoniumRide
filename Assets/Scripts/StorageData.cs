using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class StorageData : MonoBehaviour {

    public GameObject moduleTest;

    private string filePath;

    [System.Serializable]
    public struct DataModule
    {
        public int id;
        public GameObject module;
    }

    public List<DataModule> allModules;

	// Use this for initialization
	void Start () {

        if (Application.platform == RuntimePlatform.Android)
        {
            filePath = Application.persistentDataPath + "/AvailableModules.txt";
        }
        else
        {
            filePath = Application.persistentDataPath + "/AvailableModules.txt";
        }

        if(!File.Exists(filePath))
        {
            print(filePath);
            new FileStream(filePath, FileMode.Append).Dispose();
            
        }

        SaveModule(0);
        SaveModule(1);
        SaveModule(2);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Charge tous les modules disponibles depuis le fichier AvailableModules.txt
    /// </summary>
    /// <returns>La liste des modules disponibles pour le player
    /// </returns>
    public List<GameObject> LoadAvailableModules()
    {
        List<GameObject> availableModules = new List<GameObject>();
        StreamReader reader = new StreamReader(filePath);
        string line;
        while((line = reader.ReadLine()) != null)
        {
            GameObject module = SearchDataModuleWithId(int.Parse(line)).module;
            availableModules.Add(module);
        }
        reader.Close();
        return availableModules;
        
    }

    public DataModule SearchDataModuleWithId(int id)
    {
        return allModules.Find(x => x.id == id);
    }

    /// <summary>
    /// Enregistre un id correspondant à un module dans AvailableModules.txt
    /// </summary>
    /// <param name="id">L'id du module</param>
    public void SaveModule(int id)
    {
        StreamWriter writer = new StreamWriter(filePath, true);
        writer.WriteLine(id.ToString());
        writer.Dispose();
    }
}
