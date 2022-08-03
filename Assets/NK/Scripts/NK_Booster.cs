using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Booster : MonoBehaviour
{
    public float boostSpeed = 70f;
    public float boostTime = 5f;
    public bool isBooster = false;

    float normalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = NK_PlayerMove.Instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            NK_PlayerMove.Instance.speed = boostSpeed;
            Invoke("Initialization", boostTime);
        }
    }

    void Initialization()
    {
        NK_PlayerMove.Instance.speed = normalSpeed;
    }
}
