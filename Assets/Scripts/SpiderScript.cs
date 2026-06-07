using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public class SpiderScript : MonoBehaviour
{
    public GameObject spider;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float speed = 3f;
    private UnityEngine.Vector2 movement;
    private UnityEngine.Vector3 originalPosition;
    
    // Start is called before the first frame update
    private void Start()
    {
        originalPosition = transform.position;
       
        

    }

    // Update is called once per frame
    private void Update()
    {
        
        
        movement.x = speed * -1;
        movement.y = rigidBody.velocity.y;
        rigidBody.velocity = movement;

        if (transform.position.x <= -30)
        {
            Destroy(spider);
        }

        
        
    }

}
