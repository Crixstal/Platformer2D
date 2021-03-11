using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private float force = 6f;
    private Rigidbody rb;

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
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, 0), force * Time.deltaTime);
    }
}