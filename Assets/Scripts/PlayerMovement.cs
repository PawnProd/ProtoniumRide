using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    /// <summary>
    /// La distance entre chaque lane
    /// </summary>
    private const float LANE_DISTANCE = 3.0f;

    /// <summary>
    /// La vitesse de déplacement du player
    /// </summary>
    private float _speed = 7.0f;

    /// <summary>
    /// Le character controller du player
    /// </summary>
    private CharacterController _controller;

    /// <summary>
    /// La lane ou se situe le player
    /// </summary>
    private int _desiredLaneX = 1; // 0 = Gauche, 1 = Milieu, 2 = Droite
    private int _desiredLaneY = 1; // 0 = Haut, 1 = Milieu, 2 = Bas

    public float Speed
    {
        get
        {
            return _speed;
        }
    }

	// Use this for initialization
	void Start () {
        _controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(LevelManager.Instance.levelState == LevelState.running)
        {
            // On calcul la futur position
            Vector3 targetPosition = transform.position.z * Vector3.forward;
            targetPosition += CalculNextPosition(_desiredLaneX, false);
            targetPosition += CalculNextPosition(_desiredLaneY, true);

            // On calcul le delta de mouvement
            Vector3 moveVector = Vector3.zero;
            moveVector.x = (targetPosition.x - transform.position.x) * _speed;
            moveVector.y = (targetPosition.y - transform.position.y) * _speed; ;
            moveVector.z = _speed;

            // On déplace ensuite le player
            _controller.Move(moveVector * Time.deltaTime);
        }

	}

    /// <summary>
    /// Déplace le player sur une lane horizontale en fonction de <paramref name="goingRight"/>
    /// </summary>
    /// <param name="goingRight">Détermine si le player se déplace à droite ou non</param>
    public void MoveLaneX(bool goingRight)
    {
        // On change de lane en fonction de si on va à droite ou non
        _desiredLaneX += (goingRight) ? 1 : -1;
        // On restreint les valeurs entre 0 et 2
        _desiredLaneX = Mathf.Clamp(_desiredLaneX, 0, 2);
    }

    /// <summary>
    ///  Déplace le player sur une lane verticale en fonction de <paramref name="goingDown"/>
    /// </summary>
    /// <param name="goingDown">Détermine si le player se déplace en bas ou non</param>
    public void MoveLaneY(bool goingDown)
    {
        _desiredLaneY += (goingDown) ? 1 : -1;
        _desiredLaneY = Mathf.Clamp(_desiredLaneY, 0, 2);
    }

    /// <summary>
    /// Calcul la futur position du player
    /// </summary>
    /// <param name="desiredLane">La lane sur laquelle va se trouver le player</param>
    /// <param name="vertical"> Si le joueur a effectué un mouvement vertical ou non </param>
    /// <returns></returns>
    public Vector3 CalculNextPosition(int desiredLane, bool vertical)
    {
        if(desiredLane == 0)
        {
            return (vertical) ? Vector3.up * LANE_DISTANCE : Vector3.left * LANE_DISTANCE;
        }
        else if(desiredLane == 2)
        {
            return (vertical) ? Vector3.down * LANE_DISTANCE : Vector3.right * LANE_DISTANCE;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
