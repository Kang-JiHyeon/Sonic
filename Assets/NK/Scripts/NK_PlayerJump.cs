using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerJump : MonoBehaviour
{
    float jumpSpeed;

    void Start()
    {
        jumpSpeed = 10.0f;
    }

    void Update()
    {
        if (NK_PlayerMove.Instance.isJumping)
        {
            transform.Rotate(jumpSpeed, 0, 0);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
