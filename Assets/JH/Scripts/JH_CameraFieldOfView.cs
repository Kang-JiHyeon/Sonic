using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 부스터 상태에 따라 FOV 값을 다르게 하고 싶다.
// 1. Move
// 2. Booster

// 플레이어가 부스터 상태일 때 Post-process volume을 켜고 싶다.
public class JH_CameraFieldOfView : MonoBehaviour
{
    NK_Booster player;
    Camera cam;
    JH_PathFollower camManager;
    GameObject postProcess;

    public float originFOV;
    public float boosterFOV = 70f;
    public float speed = 3f;
    bool isPP = false;
    float fov;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<NK_Booster>();
        cam = GetComponent<Camera>();
        camManager = GetComponentInParent<JH_PathFollower>();
        postProcess = transform.GetChild(0).gameObject;
        //postProcess.SetActive(false);
        originFOV = cam.fieldOfView;
    }


    // Update is called once per frame
    void Update()
    {

        // 2. 부스터 상태
        if (player.isBooster)
        {
            fov = boosterFOV;
            isPP = true;
        }
        // 3. 일반
        else
        {
            fov = originFOV;
            isPP = false;
        }

        // 1. 레일 위
        if (camManager.isCameraRail)
        {
            fov = originFOV;
        }

        // camera FOV 변경
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, speed * Time.deltaTime);

        // fov와 근사한 값이면 fov로 초기화
        if (Mathf.Abs(fov - cam.fieldOfView) < 0.1f)
        {
            cam.fieldOfView = fov;
        }

        //// 포스터 프로세스 부스터 효과 true/false
        //postProcess.SetActive(isPP);
    }
}
