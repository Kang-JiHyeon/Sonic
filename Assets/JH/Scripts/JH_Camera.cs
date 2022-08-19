using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 빈 오브젝트로 카메라 위치 정해두고, 타겟 방향 정해서 카메라 방향을 lerp로 이동하자! (카메라 회전은 이후에..?)
// 카메라 위치가 변경될 때 카메라의 forward 방향을 타겟의 방향으로 지정한다.


// 1. 일반
// CamPos1에 위치하고 싶다.
// 플레이어를 따라가고 싶다. foward = z축

// 2. 부스터
// 일반보다 조금 더 뒤쪽

// 2. 횡스크롤
// 카메라의 일정 지점에 플레이어가 오도록 하되 자유롭게... foward = -x축
public class JH_Camera : MonoBehaviour
{
    public Vector3 offset;
    GameObject player;
    // 일반
    public Transform camPos1;
    public float camMoveSpeed = 0.7f;
    // 옆
    public Transform camPos2;

    public bool isHorizontal = false;  // Horizontal
    public bool isCamMove = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = camPos1.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // camPos1의 위치로 이동하고 싶다.
        if (!isHorizontal)
        {
            transform.position = Vector3.Lerp(transform.position, camPos1.position, Time.deltaTime * camMoveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, camPos1.rotation, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(transform.position, camPos1.position) < 0.1f)
            {
                transform.position = camPos1.position;
                transform.rotation = camPos1.rotation;
            }
        }
        
        // camPos2의 위치로 이동하고 싶다.
        if (isHorizontal && isCamMove)
        {
            transform.position = Vector3.Lerp(transform.position, camPos2.position, Time.deltaTime * camMoveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, camPos2.rotation, Time.deltaTime * camMoveSpeed);

            if (Vector3.Distance(transform.position, camPos2.position) < 0.1f)
            {
                transform.position = camPos2.position;
                transform.rotation = camPos2.rotation;
                isCamMove = false;
            }
        }
    }
}
