using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;
    [SerializeField]
    private Camera myCamera = null;

    private float camera_speed = 5.0f;
    private float camera_posZ;

    void Awake()
    {
        camera_posZ = myCamera.transform.position.z;
    }

    void Update()
    {
        Vector3 destination = new Vector3(player.transform.position.x, player.transform.position.y + 3, camera_posZ);
        myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, destination, camera_speed);
    }
}