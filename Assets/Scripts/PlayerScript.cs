using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpStrength = 10f;
    private Vector2 movement;
    public Rigidbody2D rigidBody;
    
    private bool grounded;
    private Animator anim;
    public float playerLives = 3f;
    [SerializeField] private float extraJump = 0f;
    [SerializeField] private float invincibilityValue = 0f;
    [SerializeField] private bool hasGroundItem;
    public GameObject platformPrefab;
    private Vector3 platformSpawnPoint;
    private bool hasSpeedItem;
    private float speedItemTimer;
    
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void Update()
    {
        platformSpawnPoint = new Vector3(transform.position.x, 
        transform.position.y + 5.5f, 0);

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        float input = Input.GetAxisRaw("Horizontal");
        movement.x = input * playerSpeed * Time.deltaTime;
        transform.Translate(movement);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded == true) 
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump >= 1f 
                  && grounded == false)
        {
            
            extraJump -= 1f;
            Jump();
            Debug.Log($"extrajump = {extraJump}");
        }

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
 
        anim.SetBool("walk", horizontalInput != 0);

        if (Input.GetKeyDown(KeyCode.X) && hasGroundItem == true)
        {
            
            hasGroundItem = false;
            Instantiate(platformPrefab, platformSpawnPoint, transform.rotation);
        }

        if (hasSpeedItem == true)
        {
            
            speedItemTimer += Time.deltaTime;
            if (hasSpeedItem == true && speedItemTimer >= 15)
        {
            hasSpeedItem = false;
            Debug.Log("has speed item" + false);
            playerSpeed = playerSpeed/2;
        }
        }
        


        
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || 
            other.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }

        
        if (invincibilityValue >= 1f && 
                 other.gameObject.CompareTag("Enemy")||
            invincibilityValue >= 1f && 
                 other.gameObject.CompareTag("Crocodile Enemy"))
        {
            invincibilityValue -= 1f;
            Debug.Log($"invincibility value = {invincibilityValue}");
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Enemy") || 
                other.gameObject.CompareTag("Crocodile Enemy"))
        {
            LoseLife();
        }

       
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") ||
            other.gameObject.CompareTag("Platform"))
        {
            grounded = false;
        }

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("Jump Item"))
        {
            extraJump += 1f;
            Debug.Log($"extrajump = {extraJump}");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Invincibility Item"))
        {
            invincibilityValue += 1f;
            Debug.Log($"invincibility value = {invincibilityValue}");
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Ground Item"))
        {
            hasGroundItem = true;
            Debug.Log("hasgrounditem =" + hasGroundItem);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Speed Item"))
        {
            hasSpeedItem = true;
            Debug.Log("Has speed item is" + hasSpeedItem);
            playerSpeed = playerSpeed * 2;
            Destroy(other.gameObject);
        }

        if (invincibilityValue >= 1f && 
                 other.gameObject.CompareTag("Enemy"))
        {
            invincibilityValue -= 1f;
            Debug.Log($"invincibility value = {invincibilityValue}");
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }

    private void Jump()
    {
        
        rigidBody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    private void LoseLife()
    {
        playerLives -= 1;
        Debug.Log("Player lost life");
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
            Debug.Log($"Player lost all lives. Player has {playerLives} hearts");
        }
    }

}
