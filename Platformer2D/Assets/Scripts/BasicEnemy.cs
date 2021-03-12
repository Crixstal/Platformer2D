using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    private float distance;
    [SerializeField]
    private Transform start = null;
    [SerializeField]
    private Transform end = null;

    void Update()
    {
        distance = Mathf.PingPong(Time.time, speed);
        transform.position = Vector3.Lerp(start.position, end.position, distance / speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal == new Vector3(0f, -1f, 0f))
                Destroy(gameObject);
        }
    }
}