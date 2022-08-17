using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_ShuckShuck : MonoBehaviour
{
    public float speed = 3f;
    public TrailRenderer trailRenderer;

    CharacterController cc;
    Vector3 movement;
    float rightMax = 3.0f;
    float leftMax = -3.0f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        trailRenderer.enabled = true;
        movement = cc.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = new Vector3(transform.position.x + leftMax, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement = new Vector3(transform.position.x + rightMax, transform.position.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, movement, Time.deltaTime * speed);
    }
}
