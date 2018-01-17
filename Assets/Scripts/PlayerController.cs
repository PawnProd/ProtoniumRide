using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    /// <summary>
    /// Le behavior mouvement du player
    /// </summary>
    private PlayerMovement pMove;

    /// <summary>
    /// Le nom du joueur
    /// </summary>
    public string playerName;

    /// <summary>
    /// Ressource amassé durant la partie
    /// </summary>
    public int NbProtonium { get; set; }

    /// <summary>
    /// Distance parcourue durant la partie
    /// </summary>
    public float DistanceAchieved { get; set; }

    /// <summary>
    /// Détermine si le joueur est mort ou non
    /// </summary>
    public bool isDead;

	// Use this for initialization
	void Start () {
        pMove = GetComponent<PlayerMovement>();
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(LevelManager.Instance.levelState == LevelState.running)
        {
            if (MobileInput.Instance.SwipeLeft)
            {
                pMove.MoveLaneX(false);
            }
            else if (MobileInput.Instance.SwipeRight)
            {
                pMove.MoveLaneX(true);
            }
            else if (MobileInput.Instance.SwipeUp)
            {
                pMove.MoveLaneY(false);
            }
            else if (MobileInput.Instance.SwipeDown)
            {
                pMove.MoveLaneY(true);
            }

            // On calcul la distance parcourue
            DistanceAchieved += pMove.Speed * Time.deltaTime;
        }
      
	}
}
