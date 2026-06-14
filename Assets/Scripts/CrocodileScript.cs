using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CrocodileScript : MonoBehaviour
{
    public GameObject crocodile;
    private float timer = 0f;
    public Rigidbody2D rigidBody;
    private UnityEngine.Vector2 movement;
    public float targetAngle;
    float r;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer +=Time.deltaTime;

        movement.y = timer * 2;

        if (transform.position.y >= -13.7)
        {
            movement.y = 0 * rigidBody.velocity.y;

            
            Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, transform.forward);
            
            float rotationSpeed = 1f;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        }

        if (timer >= 10)
        {
            movement.y = -1;

            Quaternion newTargetRotation = Quaternion.AngleAxis((targetAngle - targetAngle), transform.forward);
            float rotationSpeed = 3f;
            transform.rotation = Quaternion.Lerp(transform.rotation, newTargetRotation, rotationSpeed * Time.deltaTime);
        }

        

        rigidBody.velocity = movement;
    }
}
