using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; //Target of the camera
    public float smoothing; //Smooths camera adjustment
    public Vector2 maxPosition; //x,y vector for setting maximum boundary position
    public Vector2 minPosition; //x,y vector for setting minimum boundary position


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position) //If not the same position as target player, begin adjustments
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            //Establishes the camera boundary
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            //Sets the follow for the camera as the player/target moves
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
