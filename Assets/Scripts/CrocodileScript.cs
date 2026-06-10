using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CrocodileScript : MonoBehaviour
{
    public int rotatorValue = -1;
    private float timer = 0f;
    public Rigidbody2D rigidBody;
    private UnityEngine.Vector2 movement;
    public float targetAngle = 90f;
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

        if (timer >= 4)
        {
            movement.y = 0 * rigidBody.velocity.y;

            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref r, 0.5f);

            transform.rotation = Quaternion.Euler(0,0, Angle);
        }

        rigidBody.velocity = movement;
    }
}
