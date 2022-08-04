using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -20;

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

        Vector3 dir = new Vector3(h, 0, v);

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

        if (NK_PlayerJump.Instance.isJumping)
        {
            //NK_PlayerJump.Instance.Jump(transform);
        }

        cc.SimpleMove(dir * speed);
    }
}
