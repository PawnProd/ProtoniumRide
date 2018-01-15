using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour {

    private const float DEADZONE = 100.0f;

    public static MobileInput Instance { set; get; }

    /// <summary>
    /// Lorsqu'on tape avec le doigt sur le téléphone
    /// </summary>
    private bool _tap;
    /// <summary>
    /// Lorsqu'on fait glisser le doigt vers le haut
    /// </summary>
    private bool _swipeUp;
    /// <summary>
    /// Lorsqu'on fait glisser le doigt vers le bas
    /// </summary>
    private bool _swipeDown;
    /// <summary>
    /// Lorsqu'on fait glisser le doigt vers la droite
    /// </summary>
    private bool _swipeRight;
    /// <summary>
    /// Lorsqu'on fait glisser le doigt vers la gauche
    /// </summary>
    private bool _swipeLeft;

    /// <summary>
    /// Delta du glissement du doigt
    /// </summary>
    private Vector2 _swipeDelta;
    /// <summary>
    /// Position de départ du doigt
    /// </summary>
    private Vector2 _startTouch;

    // Getters et Setters
    public bool Tap { get { return _tap; } }
    public bool SwipeUp { get { return _swipeUp; } }
    public bool SwipeDown { get { return _swipeDown; } }
    public bool SwipeRight { get { return _swipeRight; } }
    public bool SwipeLeft { get { return _swipeLeft; } }
    public Vector2 SwipeDelta { get { return _swipeDelta; } }

    // Use this for initialization
    void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {

        // On reset l'ensemble des booleans
        _tap = _swipeUp = _swipeDown = _swipeRight = _swipeLeft = false;

        // On check les Inputs

        #region Standalone Input
        if(Input.GetMouseButtonDown(0))
        {
            _tap = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {

            _startTouch = _swipeDelta = Vector2.zero;
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length != 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                _tap = true;
                _startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _startTouch = _swipeDelta = Vector2.zero;
            }
        }
     
        #endregion

        // On calcul la distance du swipe
        _swipeDelta = Vector2.zero;

        if(_startTouch != Vector2.zero)
        {
            // On check avec les inputs mobile
            if(Input.touches.Length != 0)
            {
                _swipeDelta = Input.touches[0].position - _startTouch;
            }

            // IDEM avec les inputs PC
            if(Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
            }
        }

        // On vérifie si on est dans la deadzone
        if(_swipeDelta.magnitude > DEADZONE)
        {
            // C'est un swipe confirmé !
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Droite ou Gauche
                if(x < 0)
                {
                    _swipeLeft = true;
                }
                else
                {
                    _swipeRight = true;
                }
            }
            else
            {
                // Haut ou Bas
                if(y < 0)
                {
                    _swipeDown = true;
                }
                else
                {
                    _swipeUp = true;
                }
            }

            // On reset
            _startTouch = _swipeDelta = Vector2.zero;
        }
    }
}
