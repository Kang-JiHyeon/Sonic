using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �ν��� ���¿� ���� FOV ���� �ٸ��� �ϰ� �ʹ�.
// 1. Move
// 2. Booster

// �÷��̾ �ν��� ������ �� Post-process volume�� �Ѱ� �ʹ�.
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

        // 2. �ν��� ����
        if (player.isBooster)
        {
            fov = boosterFOV;
            isPP = true;
        }
        // 3. �Ϲ�
        else
        {
            fov = originFOV;
            isPP = false;
        }

        // 1. ���� ��
        if (camManager.isCameraRail)
        {
            fov = originFOV;
        }

        // camera FOV ����
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, speed * Time.deltaTime);

        // fov�� �ٻ��� ���̸� fov�� �ʱ�ȭ
        if (Mathf.Abs(fov - cam.fieldOfView) < 0.1f)
        {
            cam.fieldOfView = fov;
        }

        //// ������ ���μ��� �ν��� ȿ�� true/false
        //postProcess.SetActive(isPP);
    }
}
