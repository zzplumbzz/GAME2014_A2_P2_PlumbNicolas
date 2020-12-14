using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButtonScript : MonoBehaviour
{
    public Vector2 movement;
    public float vertical;

    public PlayerScript PS;
    private Rigidbody2D m_rigidBody2D;
    public float jumpForce;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  movement.y = Vertical;
    }
    public void onButtonPress()
    {
        void onJumpButtonPress()
            {
           
                // jump
                m_rigidBody2D.AddForce(Vector2.up * jumpForce);

                isJumping = true;


            }/*if else
            {
                isJumping = false;
            }*/
        }
    }
