using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    /// <summary>
    /// Offset de la caméra
    /// </summary>
    public Vector3 offset;

    /// <summary>
    /// L'objet que la caméra doit suivre
    /// </summary>
    public Transform lookAt;

    /// <summary>
    /// La vitesse de déplacement de la caméra
    /// </summary>
    public float speed = 2.0f;

    // Use this for initialization
    void Start()
    {
        transform.position = lookAt.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = lookAt.position + offset;
        desiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime );
    }
}
