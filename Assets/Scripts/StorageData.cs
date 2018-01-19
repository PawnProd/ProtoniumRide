using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class StorageData : MonoBehaviour {

    private static string filePath;

    [System.Serializable]
    public struct DataModule
    {
        public int id;
        public GameObject module;
    }

    public List<DataModule> allModules;

    private void Awake()
    {
        SetPath();
    }

    // Use this for initialization
    void Start () {

        

        if(!File.Exists(filePath))
        {
            print(filePath);
            new FileStream(filePath, FileMode.Append).Dispose();

            // Les modules de bases
            SaveModule(0);
            SaveModule(1);
            SaveModule(4);
        }



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

    /// <summary>
    /// Récupère tous les ID des modules disponibles
    /// </summary>
    /// <returns> les ID des modules disponibles</returns>
    public static List<int> GetAllIdAvailable()
    {
        SetPath();
        List<int> availableId = new List<int>();
        StreamReader reader = new StreamReader(filePath);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            availableId.Add(int.Parse(line));
        }
        reader.Close();
        return availableId;

    }

    /// <summary>
    /// Récupère la data en fonction de l'id
    /// </summary>
    /// <param name="id"> L'id du module à récupérer</param>
    /// <returns>La data du module</returns>
    public DataModule SearchDataModuleWithId(int id)
    {
        return allModules.Find(x => x.id == id);
    }

    /// <summary>
    /// Enregistre un id correspondant à un module dans AvailableModules.txt
    /// </summary>
    /// <param name="id">L'id du module</param>
    public static void SaveModule(int id)
    {
        StreamWriter writer = new StreamWriter(filePath, true);
        writer.WriteLine(id.ToString());
        writer.Dispose();
    }

    public static void SetPath()
    {
        if(filePath == null)
        {
            filePath = Application.persistentDataPath + "/AvailableModules.txt";
        }
    }
}
