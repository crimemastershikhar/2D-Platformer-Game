using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrolnew : MonoBehaviour
{
    public Animator animator;
    public float Speed;
    public float JumpForce;
    public scorecontroller scorecontroller;
    public gameovercontroller gameovercontroller;
    public gamecontrol gc;
    const float GroundedRadius = .2f;
    public float health;
    private bool Grounded;
    private float horizontal;
    private bool jump = false;
//    private bool crouch = false;
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] Transform GroundCheck;
    public Rigidbody2D rb2d;

   public void KillPlayer()
        {
        if(health <= 0)
        {
            animator.SetBool("Die", true);
            SoundManager.Instance.Play(Sounds.PlayerDeath);
            Invoke(nameof(DieAnimation), 1.5f);
        }
    }
    private void DieAnimation()
    {
        gameovercontroller.PlayerDied();
        Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<Patrol>() != null)
        {
            health -= 1;
            gc.healthsystem(health);
        }
        KillPlayer();
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            animator.SetBool("IsJump", true);
        }
//        KillPlayer();
    }
    private void FixedUpdate()
    {
        bool wasGrounded = Grounded;
        Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        for(int i = 0; i<colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Grounded = true;
                if(!wasGrounded)
                {
                    animator.SetBool("IsJump", false);
                }
            }
        }
        MoveCharacter(horizontal, jump);
        playermovementanimation(horizontal);
        jump = false;
    }
    
    public void pickupKey()
    {
        Debug.Log("Picked the Key");
        scorecontroller.Increasescore(100);
    }

    private void MoveCharacter(float horizontal, bool jump)
    {
        Vector3 position = transform.position;
        position.x += horizontal* Speed * Time.deltaTime;
        transform.position = position;
        if (Grounded && jump)
        {
            Grounded = false;
            rb2d.AddForce(new Vector2(0f, JumpForce));
        }
    }
        private void playermovementanimation(float horizontal)
        {
            animator.SetFloat("speed", Mathf.Abs(horizontal));
            Vector3 scale = transform.localScale;
            if (horizontal < 0)
            {
                scale.x = -1 * Mathf.Abs(horizontal);
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(horizontal);
            }
            transform.localScale = scale;
        }
    }
