using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Vector2 movement;
    private float xSpeed;
    [SerializeField] private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        int randomInt = Random.Range(11, 22);
        xSpeed = randomInt;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = xSpeed * -1;
        movement.y = 0;
        rigidBody.velocity = movement;
    }
}
