using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �ν��� ���¿� ���� FOV ���� �ٸ��� �ϰ� �ʹ�.
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
        // �ν��� ���¶�� fov ���� ũ�� �����Ѵ�.
        if (player.isBooster)
        {
            //cam.fieldOfView = boosterFOV;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, boosterFOV, speed * Time.deltaTime);

            // boosterFOV�� �ٻ��� ���̸� boosterFOV�� �ʱ�ȭ
            if(boosterFOV - cam.fieldOfView < 0.1f)
            {
                cam.fieldOfView = boosterFOV;
            }
        }
        // �ν��� ���°� �ƴ϶�� ���� fov�� �����Ѵ�.
        else
        {
            //cam.fieldOfView = originFOV;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, originFOV, speed * Time.deltaTime);
            // originFOV�� �ٻ��� ���̸� originFOV�� �ʱ�ȭ
            if (cam.fieldOfView - originFOV < 0.1f)
            {
                cam.fieldOfView = originFOV;
            }
        }
    }
}
