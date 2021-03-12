using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    private float speed = 5f;
    public bool isDestroyed;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isDestroyed = true;
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }
}
