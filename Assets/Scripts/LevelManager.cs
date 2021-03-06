﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gère le niveau de jeu
/// </summary>
public class LevelManager : MonoBehaviour {

    /// <summary>
    /// Instance du level manager
    /// </summary>
    public static LevelManager Instance;

    /// <summary>
    /// Le manager de l'ATH
    /// </summary>
    public ATHManager athManager;

    /// <summary>
    /// La position du premier module
    /// </summary>
    public GameObject startPosition;

    /// <summary>
    /// Le décalage entre chaque module
    /// </summary>
    public Vector3 offset;

    /// <summary>
    /// Le controller du player
    /// </summary>
    public PlayerController pController;

    /// <summary>
    /// Les données du joueur stockées sur fichier
    /// </summary>
    public StorageData storeData;

    /// <summary>
    /// L'état du niveau
    /// </summary>
    public LevelState levelState;

    /// <summary>
    /// La liste des modules spawn
    /// </summary>
    private List<GameObject> _currentModules = new List<GameObject>();

    /// <summary>
    /// Détermine si la fin de jeu a été enclenché
    /// </summary>
    private bool endGame;

    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        endGame = false;
        ModulesPool.FillPool(storeData.LoadAvailableModules());
        Pause();
        Spawn();
    }

    private void Update()
    {
        if(!pController.isDead)
        {
            athManager.UpdateProtoniumText(pController.NbProtonium.ToString());
            athManager.UpdateDistanceText(pController.DistanceAchieved.ToString());
        }
        else if(!endGame)
        {
            endGame = true;
            EndGame();
        }
    }

    /// <summary>
    /// Lance la partie une fois le nom entré
    /// </summary>
    public void BeginGame()
    {
        string name = athManager.GetPlayerName();
   
        if(name != "")
        {
            athManager.HideBeginPanel();
            pController.playerName = name;
            Play();
        }
        else
        {
            athManager.ShowNameInputFieldOutline();
        }
    }

    /// <summary>
    /// Spawn un module
    /// </summary>
    public void Spawn()
    {
        // Au début du jeu 
        if(_currentModules.Count == 0)
        {
            GameObject module1 = Instantiate(ModulesPool.GetRandomModule(), startPosition.transform.position, Quaternion.identity);
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

    /// <summary>
    /// Met en pause le jeu
    /// </summary>
    public void Pause()
    {
        levelState = LevelState.paused;
    }

    /// <summary>
    /// Démarre/Reprend le jeu
    /// </summary>
    public void Play()
    {
        levelState = LevelState.running;
    }

    /// <summary>
    /// Reset la partie
    /// </summary>
    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Déclenche la fin de jeu
    /// </summary>
    public void EndGame()
    {
        Pause();
        StartCoroutine(ShowEnd());

    }

    /// <summary>
    /// Affiche le panel de fin de jeu au bout de 4 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowEnd()
    {
        yield return new WaitForSeconds(4);
        athManager.ShowEndGamePanel();
        athManager.UpdateScore((int)pController.DistanceAchieved, pController.NbProtonium);
        athManager.UpdateName(pController.playerName);
        athManager.UpdateRessource(pController.NbProtonium.ToString());
        Leaderboard.SaveScoreInLeaderboard(pController.playerName, (int)pController.DistanceAchieved + pController.NbProtonium);
        PlayerPrefs.SetInt("Protonium", PlayerPrefs.GetInt("Protonium") + pController.NbProtonium);
    }
}

/// <summary>
/// Les différents état de jeu
/// </summary>
public enum LevelState
{
    running,
    paused
}
