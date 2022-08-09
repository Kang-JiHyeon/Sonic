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
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position -= transform.forward * Time.deltaTime * jumpSpeed;
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
