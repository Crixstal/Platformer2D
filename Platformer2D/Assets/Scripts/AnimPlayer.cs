using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField]
    private Animator anim = null;

    void Update()
    {
        anim.SetBool("isRunning", false);

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
            anim.SetBool("isRunning", true);
    }

    private void OnCollisionStay(Collision collision)
    {
        anim.SetBool("isJumping", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("isJumping", true);
    }
}
