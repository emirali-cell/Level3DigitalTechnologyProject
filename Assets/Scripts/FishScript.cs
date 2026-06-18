using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public GameObject fish;
    public Rigidbody2D rigidBody;
    private Vector2 movement;
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = -xSpeed;
        movement.y = rigidBody.velocity.y;
        rigidBody.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")||
            other.gameObject.CompareTag("Enemy")||
            other.gameObject.CompareTag("Platform"))
        {
            Destroy(fish);
        }
    }
}
