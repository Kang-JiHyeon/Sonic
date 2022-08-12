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
    Animator anim;
    float normalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        booster = Instantiate(boosterFactory);
        booster.SetActive(false);
        normalSpeed = NK_PlayerMove.Instance.speed;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isBooster = true;
        }

        if (isBooster)
        {
            anim.SetBool("IsBooster", true);
            NK_PlayerMove.Instance.speed = boostSpeed;
            booster.SetActive(true);
            Invoke("Initialization", boostTime);
        }

        if (booster != null)
        {
            booster.transform.position = transform.position;
        }
    }

    void Initialization()
    {
        booster = Instantiate(boosterFactory);
        booster.SetActive(false);
        anim.SetBool("IsBooster", false);
        isBooster = false;
        NK_PlayerMove.Instance.speed = normalSpeed;
    }
}
