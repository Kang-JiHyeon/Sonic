using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public static float speed = 0f;
    Vector3 movement;
    Rigidbody rigid;
    float rightMax = 5.0f;
    float leftMax = -5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(Vector3.forward * speed);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed = 5f;
            movement = transform.position;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = new Vector3(transform.position.x + leftMax, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement = new Vector3(transform.position.x + rightMax, transform.position.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, movement, Time.deltaTime * 10f);

        /*        Vector3 dir = Vector3.right * h + Vector3.forward * v) * dir;
                dir.Normalize();*/

        //transform.position += dir * speed * Time.deltaTime;
    }
}
