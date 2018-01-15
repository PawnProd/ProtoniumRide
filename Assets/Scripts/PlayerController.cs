using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    /// <summary>
    /// Le behavior mouvement du player
    /// </summary>
    private PlayerMovement pMove;

	// Use this for initialization
	void Start () {
        pMove = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (MobileInput.Instance.SwipeLeft)
        {
            pMove.MoveLaneX(false);
        }
        else if (MobileInput.Instance.SwipeRight)
        {
            pMove.MoveLaneX(true);
        }
        else if(MobileInput.Instance.SwipeUp)
        {
            pMove.MoveLaneY(false);
        }
        else if (MobileInput.Instance.SwipeDown)
        {
            pMove.MoveLaneY(true);
        }
	}
}
