using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// curvePos 태그를 가진 오브젝트와 
public class JH_CamManager : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    Vector3 dir;
    float dirX, dirY;
    float spinSpeed = 2f;
    // Start is called before the first frame update
    public static JH_CamManager Instance;
    Vector3 groundAxis;
    Vector3 rayPos;

    //public Transform curvePos;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //rayPos = transform.position + new Vector3(0, 1, 0);
        offset = new Vector3(0, 5, -9);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        //transform.rotation = Quaternion.Euler(NK_PlayerMove.Instance.dir.y, NK_PlayerMove.Instance.dir.x, 0);
        //transform.LookAt(player.transform);
        //Ray();
    }

    private void Ray()
    {
        // Ray 필요
        // 시작 위치, 시선 방향
        // 카메라에서 플레이어 위치로 레이를 쏜다.
        Ray ray = new Ray(rayPos, player.transform.position);

        // RaycastHit
        RaycastHit hitInfo;

        // Ray를 던진다.
        // 만약 충돌했다면
        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            // 부딪힌 지점의 Trasform 정보를 알고 싶다.
            groundAxis = hitInfo.transform.InverseTransformPoint(hitInfo.transform.position);
            //groundAxis = hitInfo.transform.transform.position;
            print(groundAxis);

            transform.forward = groundAxis;
        }
    }
}

// 커브 트리거 발동 -> CamManager 회전
