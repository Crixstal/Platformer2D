using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;
    [SerializeField]
    private float force = 5.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetContact(0).normal == new Vector3(0f, -1f, 0f))
                Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.LookAt(player);

            //transform.position = Vector3.MoveTowards(transform.position, player.position, force * Time.deltaTime);
            rb.AddForce(-player.position * force, ForceMode.Impulse);
        }

    }
}
