using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerJump : MonoBehaviour
{
    NK_PlayerJump playerJump;
    float jumpSpeed;

    void Start()
    {
        jumpSpeed = 30.0f;
        playerJump = this;
    }

    void Update()
    {
        if (NK_PlayerMove.Instance.isJumping)
        {
            Vector3 dir = transform.root.InverseTransformDirection(transform.root.right);
            dir.Normalize();
            transform.Rotate(dir * jumpSpeed);
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
            transform.root.localEulerAngles = Vector3.zero;
            playerJump.enabled = false;
        }
    }
}
