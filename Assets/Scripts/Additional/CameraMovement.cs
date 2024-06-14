using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing;
    public Vector3 cameraPosition;
    // public Vector2 maxPosition;
    // public Vector2 minPosition;

    void Start()
    {
        // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // void LateUpdate()
    // {
    //     if (transform.position != target.position)
    //     {
    //         Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
    //         targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
    //         targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
    //         transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
    //     }
    // }

    void LateUpdate()
    {
        if (transform.position != cameraPosition)
        {
            Vector3 targetPosition = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
