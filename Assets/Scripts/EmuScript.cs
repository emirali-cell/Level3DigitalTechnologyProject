using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuScript : MonoBehaviour
{
    public GameObject emu;
    private Vector2 movement;
    private float xSpeed;
    [SerializeField] private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        int randomInt = Random.Range(12, 22);
        xSpeed = randomInt;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = xSpeed * -1;
        movement.y = rigidBody.velocity.y;
        rigidBody.velocity = movement;

        if (transform.position.x <= -30)
        {
            Destroy(emu);
        }

    }
}
