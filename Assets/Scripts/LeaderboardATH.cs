using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardATH : MonoBehaviour {

    public List<LeaderBoardLine> leaderboard;

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
