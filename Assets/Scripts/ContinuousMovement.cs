using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class makes an object move in a specified direction
// Can be used for projectiles or simple NPC-behaviours
// Call StartMovement or StopMovement from other events to control the movement of this object
// If you don't know how to use UnityEvents, watch this video first: https://play.his.se/media/UnityEvents/0_nq9m8qin

public class ContinuousMovement : MonoBehaviour
{
    [Tooltip("The direction and speed of the movement. A value of (1,0,0) will move the object to the right at the speed of 1 m/s")]
    [SerializeField] private Vector3 velocity;

    [Tooltip("Set to true if the object should start moving as soon as it is loaded into the scene. Set to false if you want to control when the object should start moving.")]
    [SerializeField] private bool activeOnStart;

    private Vector3 originalPosition;

    private bool active;
    
    // Awake is called before the first frame update
    void Awake()
    {
        originalPosition = transform.position;
        
        if (activeOnStart)
            StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        // update position of this object if the movement is active
        if (active)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }

    // Call this if you want to start moving the object
    public void StartMovement()
    {
        active = true;
    }

    // Call this if you want to stop moving the object (for example when it reaches a Trigger-collider).
    public void StopMovement()
    {
        active = false;
    }

    // Call this if you want to reset the object back to it's start-position
    public void ResetTransform(bool active = false)
    {
        transform.position = originalPosition;
        
        if (!this.active && active)
            StartMovement();
        else if (this.active && !active)
            StopMovement();
    }

    public void InvertVelocity()
    {
        velocity.x = -velocity.x;
        velocity.y = -velocity.y;
        velocity.z = -velocity.z;
    }
}
