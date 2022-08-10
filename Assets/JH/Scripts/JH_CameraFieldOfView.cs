using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 부스터 상태에 따라 FOV 값을 다르게 하고 싶다.
// 1. Move
// 2. Booster
public class JH_CameraFieldOfView : MonoBehaviour
{
    public float originFOV;
    public float boosterFOV = 80f;
    public float speed = 3f;
    NK_Booster player;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<NK_Booster>();
        cam = GetComponent<Camera>();
        originFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        // 부스터 상태라면 fov 값을 크게 설정한다.
        if (player.isBooster)
        {
            //cam.fieldOfView = boosterFOV;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, boosterFOV, speed * Time.deltaTime);

            // boosterFOV와 근사한 값이면 boosterFOV로 초기화
            if(boosterFOV - cam.fieldOfView < 0.1f)
            {
                cam.fieldOfView = boosterFOV;
            }
        }
        // 부스터 상태가 아니라면 원래 fov로 설정한다.
        else
        {
            //cam.fieldOfView = originFOV;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, originFOV, speed * Time.deltaTime);
            // originFOV와 근사한 값이면 originFOV로 초기화
            if (cam.fieldOfView - originFOV < 0.1f)
            {
                cam.fieldOfView = originFOV;
            }
        }
    }
}
