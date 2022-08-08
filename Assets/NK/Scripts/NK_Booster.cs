using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Booster : MonoBehaviour
{
    public GameObject boosterFactory;
    public float boostSpeed = 50f;
    public float boostTime = 5f;
    public bool isBooster = false;

    GameObject booster;
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
            isBooster = true;
        }

        if (isBooster)
        {
            NK_PlayerMove.Instance.speed = boostSpeed;
            //booster = Instantiate(boosterFactory);
            Invoke("Initialization", boostTime);
        }

        if (booster != null)
        {
            booster.transform.position = transform.position;
        }
    }

    void Initialization()
    {
        isBooster = false;
        NK_PlayerMove.Instance.speed = normalSpeed;
    }
}
