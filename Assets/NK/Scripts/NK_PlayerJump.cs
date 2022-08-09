using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerJump : MonoBehaviour
{
    float jumpSpeed;

    void Start()
    {
        jumpSpeed = 30.0f;
    }

    void Update()
    {
        if (NK_PlayerMove.Instance.isJumping)
        {
            Vector3 dir = transform.root.forward;
            transform.Rotate(new Vector3(jumpSpeed, 0, 0));
        }
    }
}
