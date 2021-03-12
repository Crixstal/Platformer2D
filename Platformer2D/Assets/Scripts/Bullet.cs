using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    private float speed = 2f;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }
}
