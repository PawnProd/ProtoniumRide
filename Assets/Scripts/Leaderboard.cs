using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class Leaderboard : MonoBehaviour {

    /// <summary>
    /// La liste des scores stockés sur le fichier
    /// </summary>
    public static List<ScoreLeaderboard> listScore = new List<ScoreLeaderboard>();

    /// <summary>
    /// Le chemin d'accès vers le fichier de score
    /// </summary>
    private static string _path = Application.persistentDataPath + "/leaderboard.dat";

    /// <summary>
    /// Détermine si le ficher de leaderboard a déjà été chargé
    /// </summary>
    private static bool alreadyLoad = false;


    /// <summary>
    /// Structure des scores du leaderboard
    /// </summary>
    [System.Serializable]
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
        if(File.Exists(_path) && !alreadyLoad)
        {
            print("Coucou 2 !");
            alreadyLoad = true;
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
        int position = SearchPosition(score);
        
        ScoreLeaderboard newScore = new ScoreLeaderboard
        {
            position = position,
            name = playerName,
            score = score
        };

        print(position);
        listScore.Insert(position, newScore);
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(_path))
        {
            print("Existe déjà !");
            FileStream file = File.Open(_path, FileMode.Open);
            bf.Serialize(file, listScore);
            file.Close();
        }
        else
        {
            print("Coucou");
            FileStream file = File.Create(_path);
            bf.Serialize(file, listScore);
            file.Close();
        }

       

    }

    public static int SearchPosition(int score)
    {
        int i = 0;

        if(listScore.Count == 0)
        {
            return 0;
        }

        while(i < listScore.Count && listScore[i].score > score)
        {
            ++i;
        }

        return i;
    }
}


