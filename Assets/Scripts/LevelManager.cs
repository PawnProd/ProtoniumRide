using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    /// <summary>
    /// Instance du level manager
    /// </summary>
    public static LevelManager Instance;

    /// <summary>
    /// La position du premier module
    /// </summary>
    public Vector3 startPosition;

    /// <summary>
    /// Le décalage entre chaque module
    /// </summary>
    public Vector3 offset;

    public GameObject testModule;

    /// <summary>
    /// La liste des modules spawn
    /// </summary>
    private List<GameObject> _currentModules = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ModulesPool.AddModule(testModule);
        Spawn();
    }

    /// <summary>
    /// Spawn un module
    /// </summary>
    public void Spawn()
    {
        // Au début du jeu 
        if(_currentModules.Count == 0)
        {
            GameObject module1 = Instantiate(ModulesPool.GetRandomModule(), startPosition, Quaternion.identity);
            GameObject module2 = Instantiate(ModulesPool.GetRandomModule(), module1.transform.position + offset, Quaternion.identity);

            _currentModules.Add(module1);
            _currentModules.Add(module2);
        }
        else
        {
            GameObject module = Instantiate(ModulesPool.GetRandomModule(), _currentModules[0].transform.position + offset, Quaternion.identity);
            _currentModules.Add(module);
        }
    }

    /// <summary>
    /// Despawn un module
    /// </summary>
    /// <param name="module"></param>
    public void DeSpawn(GameObject module)
    {
        Destroy(module);
        _currentModules.RemoveAt(0);
        Spawn();
    }
}
