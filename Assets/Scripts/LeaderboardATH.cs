using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardATH : MonoBehaviour {

    /// <summary>
    /// La liste des lignes du tableau
    /// </summary>
    public List<LeaderBoardLine> leaderboard;

    private void Awake()
    {
        Leaderboard.LoadLeaderboardList();
    }

    /// <summary>
    /// Update le leaderboard
    /// </summary>
    public void UpdateLeaderboard()
    {
        int i = 0;
        while(i < Leaderboard.listScore.Count)
        {
            leaderboard[i].nameText.text = Leaderboard.listScore[i].name;
            leaderboard[i].scoreText.text = Leaderboard.listScore[i].score.ToString();
            ++i;
        }
    }
}

[System.Serializable]
public class LeaderBoardLine
{
    public Text nameText;
    public Text scoreText;
}
