using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private float distance;
    private bool isTriggered;
    //[SerializeField]
    //private float force = 6f;
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private Transform start = null;
    [SerializeField]
    private Transform end = null;

    void Update()
    {
        if (!isTriggered)
        {
            distance = Mathf.PingPong(Time.time, speed);
            transform.position = Vector3.Lerp(start.position, end.position, distance / speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal == new Vector3(0f, -1f, 0f))
                Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, 0), speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
}