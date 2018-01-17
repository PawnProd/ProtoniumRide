using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class Leaderboard : MonoBehaviour {

    /// <summary>
    /// La liste des scores stockés sur le fichier
    /// </summary>
    public static List<ScoreLeaderboard> listScore;

    /// <summary>
    /// Le chemin d'accès vers le fichier de score
    /// </summary>
    private static string _path = Application.persistentDataPath + "/leaderboard.dat";

   /// <summary>
   /// Structure des scores du leaderboard
   /// </summary>
    public struct ScoreLeaderboard
    {
        public int position;
        public string name;
        public int score;
    }

    /// <summary>
    /// Charge les scores stockés sur le fichier dans la liste des scores
    /// </summary>
	public static void LoadLeaderboardList()
    {
        if(File.Exists(_path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(_path, FileMode.Open);
            listScore = (List<ScoreLeaderboard>)bf.Deserialize(file);
            file.Close();
        }
     
    }

    /// <summary>
    /// Sauvegarde le <paramref name="score"/> du joueur <paramref name="playerName"/> dans la liste et dans le fichier
    /// </summary>
    /// <param name="playerName"> Le nom du joueur </param>
    /// <param name="score"> Le score du joueur</param>
    public static void SaveScoreInLeaderboard(string playerName, int score)
    {
        int position = listScore.FindLast(x => x.score > score).position;
        ScoreLeaderboard newScore = new ScoreLeaderboard
        {
            position = position,
            name = playerName,
            score = score
        };

        listScore.Insert(position, newScore);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(_path, FileMode.Create);
        bf.Serialize(file, listScore);
        file.Close();

    }
}


