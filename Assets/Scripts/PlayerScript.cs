using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthBar;

    

    public bool isGrounded;
    public bool isJumping;
    public Joystick joystick;
    public float joystickHorizontalSensitivity;
    public float horizontalForce;
    public float joystickVerticleSensitivity;
    public float verticleForce;

    private Rigidbody2D m_rigidBody2D;
    private SpriteRenderer m_spriteRenderer;




    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
       
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();

    }
    private void FixedUpdate()
    {
       
    }

   

   

    void _Move()
    {
        if (isGrounded)
        {
            if (joystick.Horizontal > joystickHorizontalSensitivity)
            {
                m_rigidBody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
                m_spriteRenderer.flipX = false;
            }
            else if (joystick.Horizontal < -joystickHorizontalSensitivity)
            {
                m_rigidBody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
                m_spriteRenderer.flipX = true;
            }
            else if ((joystick.Vertical > 0.6) && (!isJumping))
            {
                m_rigidBody2D.AddForce(Vector2.up * verticleForce);
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }
        }


       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;

        if (other.gameObject.CompareTag("Platform"))
        {

            isGrounded = true;
            this.transform.parent = other.transform;
        }
        else
        {
            //isGrounded = false;
        }

        // respawn
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            SceneManager.LoadScene("Game");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            this.transform.parent = null;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;

        if (other.gameObject.CompareTag("Platform"))
        {

            this.transform.parent = null;
        }

       


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

}
