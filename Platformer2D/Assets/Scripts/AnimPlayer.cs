using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isJumping", false);

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
            anim.SetBool("isRunning", true);

        if (Input.GetAxis("Jump") > 0)
            anim.SetBool("isJumping", true);
    }
}
