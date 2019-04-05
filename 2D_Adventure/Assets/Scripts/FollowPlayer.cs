using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    //initialize variables
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public float followSpeed = 12;
    public GameObject target;
    public Vector3 offset;
    public bool clampX = false;
    public bool clampY = false;
    public bool clampZ = false;
    Vector3 targetPos;


    void Start()
    {
        //set your starting position
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //see if player still exists
        if (target)
        {
            //get position
            Vector3 posNoZ = transform.position;

            //get the z position
            posNoZ.z = target.transform.position.z;

            //find out which direction the player moved if any
            Vector3 targetDirection = (target.transform.position - posNoZ);

            //find out how fast the camera moves
            interpVelocity = targetDirection.magnitude * followSpeed;

            //move 
            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            clampMotion();
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }

    private void clampMotion()
    {
        if (clampX)
            targetPos.x = 0;
        if (clampY)
            targetPos.y = 0;
        if (clampZ)
            targetPos.z = 0;
    }
}