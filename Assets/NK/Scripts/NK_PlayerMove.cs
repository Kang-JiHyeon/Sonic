using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -20;
    public bool isHorMode;

    Vector3 dir;
    Vector3 movement;
    CharacterController cc;
    float zVelocity = 0;
    float yVelocity = 0;

    public static NK_PlayerMove Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (isHorMode)
        {
            dir = Vector3.forward * h + Vector3.left * v;
        }
        else
        {
            dir = Vector3.right * h + Vector3.forward * v;
        }

        transform.rotation = Quaternion.LookRotation(dir);

        /*        zVelocity = Mathf.Clamp(zVelocity, 0, 50);

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    zVelocity += speed * Time.deltaTime;
                }

                dir.z = zVelocity;*/

        /*        yVelocity += gravity * Time.deltaTime;

                if (cc.collisionFlags == CollisionFlags.Below)
                {
                    yVelocity = 0;
                }

                dir.y = yVelocity;*/

        cc.SimpleMove(dir * speed);
    }
}
