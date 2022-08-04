using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PlayerMoveCC : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -20;
    public bool isBooster;
    public bool isHorMode;
    Vector3 dir;
    CharacterController cc;

    public static JH_PlayerMoveCC Instance;

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

            dir = new Vector3(v, 0, -h);
        }
        else
        {
            dir = new Vector3(h, 0, v);
        }

        cc.Move(dir * speed * Time.deltaTime);
    }
}
