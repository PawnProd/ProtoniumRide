using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

/// <summary>
/// Gère la persitence des données des modules
/// </summary>
public class StorageData : MonoBehaviour {

    /// <summary>
    /// Le chemin d'accès au fichier AvailableModules.txt
    /// </summary>
    private static string filePath;

    /// <summary>
    /// Lie un ID à un module
    /// </summary>
    [System.Serializable]
    public struct DataModule
    {
        /// <summary>
        /// L'id du module
        /// </summary>
        public int id;

        /// <summary>
        /// Le gameObject du module
        /// </summary>
        public GameObject module;
    }

    /// <summary>
    /// La liste de tous les modules en jeu
    /// </summary>
    public List<DataModule> allModules;

    private void Awake()
    {
        SetPath();
    }

    // Use this for initialization
    void Start () {
        CreateFile();

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

    /// <summary>
    /// Initialise le chemin d'accès au fichier des modules
    /// </summary>
    public static void SetPath()
    {
        if(filePath == null)
        {
            filePath = Application.persistentDataPath + "/AvailableModules.txt";
        }
    }

    /// <summary>
    /// Supprime le fichier des modules
    /// </summary>
    public static void ClearFile()
    {
        File.Delete(Application.persistentDataPath + "/AvailableModules.txt");
    }

    /// <summary>
    /// Génère le fichier AvailableModules.txt s'il n'existe pas déjà
    /// </summary>
    public static void CreateFile()
    {
        if (!File.Exists(filePath))
        {
            SetPath();
            print(filePath);
            new FileStream(filePath, FileMode.Append).Dispose();

            // Les modules de bases
            SaveModule(0);
            SaveModule(1);
            SaveModule(4);
        }
    }
}
