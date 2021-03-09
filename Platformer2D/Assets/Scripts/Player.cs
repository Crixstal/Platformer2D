using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 8.0f;
    [SerializeField]
    private float jumpForce = 6.0f;
    private bool isJumping;
    [SerializeField]
    private int life = 5;
    public Vector3 checkpointPos;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 velocity = collision.relativeVelocity.normalized;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            --life;

            transform.position = new Vector3(checkpointPos.x, checkpointPos.y, transform.position.z);

            //if (life <= 0)
        }

        if (collision.gameObject.tag == "MovingPlatform")
            transform.SetParent(collision.transform);
    }

    private void OnCollisionStay(Collision collision)
    {
        isJumping = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
            transform.SetParent(null);

        isJumping = true;
    }
}