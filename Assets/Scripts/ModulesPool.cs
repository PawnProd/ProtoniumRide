using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesPool : MonoBehaviour {

    /// <summary>
    /// La liste de tous les modules disponibles pour le spawn
    /// </summary>
    private static List<GameObject> _allModules = new List<GameObject>();


    /// <summary>
    /// Au lancement de la partie on remplit la piscine
    /// </summary>
    /// <param name="avalaibleModule"></param>
    public static void FillPool(List<GameObject> avalaibleModule)
    {
        _allModules = avalaibleModule;
    }

    /// <summary>
    /// Ajoute le <paramref name="module"/> dans la liste des modules spawnables
    /// </summary>
    /// <param name="module">Le module à ajouter</param>
	public static void AddModule(GameObject module)
    {
        _allModules.Add(module);
    }

    /// <summary>
    /// Récupère un module random de la liste
    /// </summary>
    /// <returns>Un module aléatoire de la liste</returns>
    public static GameObject GetRandomModule()
    {
        return _allModules[Random.Range(0, _allModules.Count)];
    }
}
