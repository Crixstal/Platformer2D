using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer flag;
    private Material cyan;

    void Awake()
    {
        flag = GetComponent<MeshRenderer>();
        cyan.color = Color.cyan;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().checkpointPos = transform.position;
            flag.material = cyan;
        }
    }
}
