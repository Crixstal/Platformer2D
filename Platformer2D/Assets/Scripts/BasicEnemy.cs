using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private float speed = 3f;
    private float distance;
    [SerializeField]
    private Transform start = null;
    [SerializeField]
    private Transform end = null;
    [SerializeField]
    private GameObject heart = null;

    void Update()
    {
        distance = Mathf.PingPong(Time.time, speed);
        transform.position = Vector3.Lerp(start.position, end.position, distance / speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal.y == -1f)
            {
                int rand = Random.Range(0, 4);
                if(rand == 1)
                    Instantiate(heart, transform.position, heart.transform.rotation);

                Destroy(gameObject);
            }
        }
    }
}