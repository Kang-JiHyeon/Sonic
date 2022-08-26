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
    float currentTime;
    AudioSource boosterSound;

    public static NK_Booster Instance;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        booster = Instantiate(boosterFactory);
        booster.SetActive(false);
        normalSpeed = NK_PlayerMove.Instance.speed;
        anim = GetComponentInChildren<Animator>();
        boosterSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isBooster = true;
            JH_SoundEffectManager.Instance.state = JH_SoundEffectManager.AudioState.Booster;
        }

        if (isBooster)
        {
            

            currentTime += Time.deltaTime;
            if (currentTime < boostTime)
            {
                anim.SetBool("IsBooster", true);
                NK_PlayerMove.Instance.speed = boostSpeed;
                booster.SetActive(true);
                
            }
            else
            {
                isBooster = false;
            }
        }
        else
        {
            Initialization();
        }

        if (booster != null)
        {
            booster.transform.position = transform.position;
        }
    }

    void Initialization()
    {
        booster.SetActive(false);
        anim.SetBool("IsBooster", false);
        NK_PlayerMove.Instance.speed = normalSpeed;
        currentTime = 0;
    }
}
