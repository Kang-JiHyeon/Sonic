using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public static float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
    }
}
