using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    private float speed = 4f;
    private float distance;
    private bool isTriggered;
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private Transform start = null;
    [SerializeField]
    private Transform end = null;
    [SerializeField]
    private GameObject heart = null;

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
            if (collision.GetContact(0).normal.y <= -0.8f)
            { 
                int rand = Random.Range(0, 2);
                if (rand == 1)
                    Instantiate(heart, transform.position, heart.transform.rotation);

                Destroy(gameObject);
            }
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