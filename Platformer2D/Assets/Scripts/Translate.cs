using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 10;

        float horizontalInput = Input.GetAxis("Horizontal");

        float jumpInput = Input.GetAxis("Jump");

        transform.Translate(new Vector2(horizontalInput, jumpInput) * moveSpeed * Time.deltaTime);
    }
}
