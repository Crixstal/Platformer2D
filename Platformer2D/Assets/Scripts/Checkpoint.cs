using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Renderer flag;
    private Material mat;
    private AudioSource connect = null;

    void Awake()
    {
        flag = GetComponent<Renderer>();
        mat = GetComponent<Renderer>().material;
        mat.color = Color.yellow;
        connect = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            connect.Play();
            other.GetComponent<Player>().checkpointPos = transform.position;
            mat.color = Color.cyan;
            flag.GetComponent<Renderer>().material = mat;
        }
    }
}
