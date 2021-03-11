using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetContact(0).normal == new Vector3(0f, -1f, 0f))
                Destroy(gameObject);
        }
    }
}