using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gère l'ath en jeu
/// </summary>
public class ATHManager : MonoBehaviour {

    /// <summary>
    /// L'objet text concernant la distance parcourue par le joueur
    /// </summary>
    public Text distanceText;

    /// <summary>
    /// L'objet text concernant le protonium amassé par le joueur
    /// </summary>
    public Text protoniumText;

    /// <summary>
    /// Le panel de fin de jeu
    /// </summary>
    public GameObject endGamePanel;

    /// <summary>
    /// Le nom des trois premiers joueurs dans le leaderboad
    /// </summary>
    public Text name1, name2, name3;

    /// <summary>
    /// Le score des trois premiers joueurs dans le leaderboard
    /// </summary>
    public Text score1, score2, score3;

    /// <summary>
    /// Le score de la partie
    /// </summary>
    public Text score;

    /// <summary>
    /// Le nombre de protonium ramassé
    /// </summary>
    public Text ressource;

    /// <summary>
    /// Le nom du joueur
    /// </summary>
    public Text nameField;

    /// <summary>
    /// Le panneau de début de jeu
    /// </summary>
    public GameObject beginPanel;

    /// <summary>
    /// L'inputField du nom du joueur
    /// </summary>
    public InputField playerName;

    /// <summary>
    /// Modifie la distance affiché dans l'ATH
    /// </summary>
    /// <param name="newDistance">La nouvelle distance</param>
	public void UpdateDistanceText(string newDistance)
    {
        distanceText.text = newDistance + "m";
    }

    /// <summary>
    /// Modifie le nombre de protonium affiché dans l'ATH
    /// </summary>
    /// <param name="newProtonium">Le nouveau nombre de protonium</param>
    public void UpdateProtoniumText(string newProtonium)
    {
        protoniumText.text = newProtonium;
    }

    /// <summary>
    /// Affiche le panel de fin de jeu
    /// </summary>
    public void ShowEndGamePanel()
    {
        endGamePanel.SetActive(true);
        for(int i = 0; i < Leaderboard.listScore.Count; ++i)
        {
            UpdateLeaderBoardName(i+1, Leaderboard.listScore[i].name);
            UpdateLeaderBoard(i+1, Leaderboard.listScore[i].score.ToString());
        }
       
     
    }

    /// <summary>
    /// Update le nom des trois premiers joueurs du leaderboard
    /// </summary>
    /// <param name="position"> La position dans le leaderboard </param>
    /// <param name="namelead1"> Le nom du joueur </param>

    public void UpdateLeaderBoardName(int position, string namelead)
    {
        switch(position)
        {
            case 1:
                name1.text = namelead;
                break;
            case 2:
                name2.text = namelead;
                break;
            case 3:
                name3.text = namelead;
                break;
        }
    }

    /// <summary>
    /// Update le score des trois premiers joueurs du leaderboard
    /// </summary>
    /// <param name="position"> La position dans le leaderboard </param>
    /// <param name="scorelead1"> Le score du joueur</param>

    public void UpdateLeaderBoard(int position, string scorelead)
    {
        switch (position)
        {
            case 1:
                score1.text = scorelead;
                break;
            case 2:
                score2.text = scorelead;
                break;
            case 3:
                score3.text = scorelead;
                break;
        }
    }

    /// <summary>
    /// Update le score final du joueur
    /// </summary>
    /// <param name="distance"> La distance parcourue durant la partie</param>
    /// <param name="ressource"> Le nombre de protonium amassé durant la partie</param>
    public void UpdateScore(int distance, int ressource)
    {
        StartCoroutine(ScoreAnim(distance, ressource));
        
    }

    /// <summary>
    /// Modifie le nom du joueur affiché à la fin de la partie
    /// </summary>
    /// <param name="playerName"> Le nom du joueur entré au début de la partie</param>
    public void UpdateName(string playerName)
    {
        nameField.text = playerName;
    }

    /// <summary>
    /// Update le nombre de protonium amassé
    /// </summary>
    /// <param name="nbRessource"> Protonium amassé</param>
    public void UpdateRessource(string nbRessource)
    {
        ressource.text = "+" + nbRessource;
    }

    /// <summary>
    /// Effectue l'animation du score 
    /// </summary>
    /// <param name="distance"> La distance parcourue durant la partie</param>
    /// <param name="ressource"> Le nombre de protonium amassé durant la partie</param>
    /// <returns></returns>
    IEnumerator ScoreAnim(int distance, int ressource)
    {
        int scoreTotal = distance + ressource;
        int currentScore = distance;

        while(currentScore < scoreTotal)
        {
            ++currentScore;
            --ressource;
            score.text = currentScore + " +" + ressource;
            yield return new WaitForSeconds(0.01f);
        }
        score.text = currentScore + " +" + ressource;
        yield return null;
    }

    /// <summary>
    /// Cache le panel de début de jeu
    /// </summary>
    public void HideBeginPanel()
    {
        beginPanel.SetActive(false);
    }

    /// <summary>
    /// Récupère le nom entré par le joueur
    /// </summary>
    /// <returns> Le nom du joueur</returns>
    public string GetPlayerName()
    {
        return playerName.text;
    }

    /// <summary>
    /// Active la composante outline de l'inputfield
    /// </summary>
    public void ShowNameInputFieldOutline()
    {
        playerName.GetComponent<Outline>().enabled = true;
    }

}
