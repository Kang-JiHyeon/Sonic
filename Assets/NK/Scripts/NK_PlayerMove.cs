using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public static float speed = 1f;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //rigid.AddForce(Vector3.forward * v * speed);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigid.AddForce(Vector3.forward * speed);
        }

/*        Vector3 dir = Vector3.right * h + Vector3.forward * v) * dir;
        dir.Normalize();*/

        //transform.position += dir * speed * Time.deltaTime;
    }
}
