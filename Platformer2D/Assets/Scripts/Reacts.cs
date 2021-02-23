using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotate))]
public class Reacts : MonoBehaviour
{
    Rotate rot;
    Material material;
    public GameObject Button;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rot = GetComponent<Rotate>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject == Button)
            rb.mass = 100.0f;

        rot.speed = 0.0f;
    }
}
