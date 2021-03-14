using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public int life = 5;
    public int score = 0;
    private float moveSpeed = 8f;
    private float jumpForce = 6f;
    private bool isJumping;
    public Vector3 checkpointPos;
    [SerializeField]
    private AudioSource error = null;
    [SerializeField]
    private AudioSource heart = null;
    [SerializeField]
    private AudioSource point = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.LookAt(transform.position + new Vector3(0, 0, horizontalInput));

        rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * jumpForce, ForceMode.Impulse);
    }

    public bool IsAlive()
    {
        if (life <= 0)
            return false;

        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.GetContact(0).normal == new Vector3(0f, 1f, 0f))
            {
                error.Play();
                ++score;
            }

            else
            {
                --life;
                transform.position = new Vector3(checkpointPos.x, checkpointPos.y, transform.position.z);
            }
        }

        /*if (collision.gameObject.CompareTag("Boss"))
        {
            if (collision.GetContact(0).normal != new Vector3(0f, 1f, 0f))
            { 
                --life;
                transform.position = new Vector3(checkpointPos.x, checkpointPos.y, transform.position.z);
            }
            else
                error.Play();
        }

        if (collision.gameObject.CompareTag("KillZone"))
        {
            --life;
            transform.position = new Vector3(checkpointPos.x, checkpointPos.y, transform.position.z);
        }
        */
        if (collision.gameObject.CompareTag("MovingPlatform"))
            transform.SetParent(collision.transform);

        if (collision.gameObject.CompareTag("Point"))
        {
            ++score;
            point.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            ++life;
            heart.Play();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isJumping = false;
        
        if (collision.GetContact(0).normal.x == -1f || collision.GetContact(0).normal.x == 1f)
            isJumping = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
            transform.SetParent(null);

        isJumping = true;
    }
}