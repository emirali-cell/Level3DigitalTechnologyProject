using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KangarooScript : MonoBehaviour
{
    public GameObject kangaroo;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float xSpeed = 3f;
    [SerializeField] private float ySpeed;
    private Vector2 movement;
    [SerializeField] private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        int randomInt = Random.Range(11, 22);
        ySpeed = randomInt;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = xSpeed * -1;
        

        if (grounded == true)
        {
           
            movement.y = ySpeed;
        }
        else if(grounded == false)
        {
            
        
            movement.y = rigidBody.velocity.y;
        }

        rigidBody.velocity = movement;

         if (transform.position.x <= -30)
        {
            Destroy(kangaroo);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || 
            other.gameObject.CompareTag("Enemy"))
        {
            grounded = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")||
            other.gameObject.CompareTag("Enemy"))
        {
            grounded = false;
           
        }
    }
}
