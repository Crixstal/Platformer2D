using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Renderer flag;
    private Material mat;

    void Awake()
    {
        flag = GetComponent<Renderer>();
        mat = GetComponent<Renderer>().material;
        mat.color = Color.yellow;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().checkpointPos = transform.position;
            mat.color = Color.cyan;
            flag.GetComponent<Renderer>().material = mat;
        }
    }
}
