using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 일반
// 플레이어와 닿이면 사라지게 하고 싶다.

// 2. 부스터
// 플레이어와 일정 거리 안에 있고, 플레이어가 부스터 상태이면 플레이어 쪽으로 이동하고 싶다.

// 3. 점수
// 링이 플레이어와 닿으면 +1
public class JH_Ring : MonoBehaviour
{
    public GameObject target;
    Rigidbody rigid;
    JH_PlayerMove player;

    float boosterDis = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        // Player의 스크립트를 가져온다.
        player = target.GetComponent<JH_PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Vector3.Distance(transform.position, target.transform.position));
        // 플레이어와 일정 거리 안에 있고, 플레이어가 부스터 상태이면 플레이어 쪽으로 이동하고 싶다.
        if (Vector3.Distance(transform.position, target.transform.position) < boosterDis && player.isBooster)
        {
            // ** 소닉 부스터 속도 맞춰 움직임 속도 수정하기!! **
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 닿으면 점수를 +1 하고 사라지고 싶다.
        if (other.gameObject.name.Contains("Player"))
        {

            // 점수 증가
            JH_Score.Instance.SCORE++;
            // 제거
            Destroy(gameObject);
        }
    }
}
