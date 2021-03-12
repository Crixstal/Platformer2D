using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField]
    private Rigidbody player = null;
    [SerializeField]
    private float jumpForce = 10f;
    private AudioSource bump;

    void Awake()
    {
        bump = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal == new Vector3(0f, -1f, 0f))
            {
                bump.Play();
                player.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * jumpForce, ForceMode.Impulse);
            }
        }
    }
}