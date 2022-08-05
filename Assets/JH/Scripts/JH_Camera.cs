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
    GameObject player;
    JH_PlayerMove playerScript;
    // 일반
    public Transform camPos1;
    // 옆
    public Transform camPos2;

    bool isVertical = false;    // Vertical
    bool isHorizontal = false;  // Horizontal

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<JH_PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1을 누르면
        if (!isHorizontal)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                isVertical = true;
            }

        }
        if (!isVertical)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                isHorizontal = true;
            }
        }

        // camPos1의 위치로 이동하고 싶다.
        if (isVertical && !isHorizontal)
        {
            transform.position = Vector3.Lerp(transform.position, camPos1.position, Time.deltaTime * 2);
            transform.forward = player.transform.position - transform.position;
            if (Vector3.Distance(transform.position, camPos1.position) < 0.1f)
            {
                transform.position = camPos1.position;
                isVertical = false;
            }
        }

        // camPos2의 위치로 이동하고 싶다.
        if (isHorizontal && !isVertical)
        {
            transform.position = Vector3.Lerp(transform.position, camPos2.position, Time.deltaTime * 2);
            transform.forward = player.transform.position - transform.position;

            if (Vector3.Distance(transform.position, camPos2.position) < 0.1f)
            {
                transform.position = camPos2.position;
                isHorizontal = false;
            }
        }
        


    }
}
