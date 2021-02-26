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
    private float camera_posY;
    private float camera_posZ;

    // Start is called before the first frame update
    void Start()
    {
        camera_posY = myCamera.transform.position.y;
        camera_posZ = myCamera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = new Vector3(player.transform.position.x, camera_posY, camera_posZ);
        myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, destination, camera_speed);
    }
}