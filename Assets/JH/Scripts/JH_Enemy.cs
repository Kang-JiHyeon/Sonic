using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 일반
// 플레이어와 부딪히면 플레이어 이동 방향 + 윗쪽으로 일정거리 날라가고 싶다.
// 필요속성 : 이동 방향, 이동 거리, 속도, 각도

// 2. 부스터
// 플레이어가 부스터를 쓰고 있고, 적과 일정 거리 안이면 날라가고 싶다.


// 3. 맵
// 맵이랑 닿으면 없어지고 싶다.
public class JH_Enemy : MonoBehaviour
{
    // 이동 방향, 이동 거리
    Rigidbody rigid;
    public GameObject target;

    
    Vector3 dir;
    Vector3 originPos;
    JH_PlayerMove player;

    public float moveDis;
    public float boosterDis;
    public float force;
    public float angleY;
    public bool isHit = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        // 튕기기 전 위치
        originPos = transform.position;
        // Player의 방향 설정 스크립트를 가져온다.
        player = target.GetComponent<JH_PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // 부딪히면
        if (isHit)
        {
            // 일정 거리 날라간 후 없어지고 싶다.
            if (Vector3.Distance(originPos, transform.position) > moveDis)
            {
                Destroy(gameObject);
                isHit = false;
            }
        }

        // 2. 부스터
        // 플레이어가 부스터를 쓰고 있고, 적과 일정 거리 안이면 날라가고 싶다.
        // NK_Booster의 isBooster 대체
        if (Vector3.Distance(transform.position, target.transform.position) < boosterDis && player.isBooster)
        {
            Hit();
        }
    }
    private void Hit()
    {
        // 적의 공격 당함 상태를 true로 만든다.
        isHit = true;

        if (player)
        {
            // 적이 튕겨나갈 방향을 구하고 싶다.
            // 플레이어의 앞방향을 구한다.
            dir = player.transform.forward;
            // y의 값만 변경한다.
            dir.y = angleY;
            dir.Normalize();
            // dir방향으로 힘을 가한다.
            rigid.AddForce(dir * 1500);
        }
    }
    //player와 부딪히면 player의 이동방향+윗쪽으로 이동하고 싶다.
    //일정 거리 이상 날라가면 없어지고 싶다.
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 대상이 Player이면
        if (other.gameObject.name.Contains("Player") && !isHit)
        {
            // 적의 공격 당함 상태를 true로 만든다.
            Hit();
        }

        // 맵이랑 닿이면 없애고 싶다.
        if(other.gameObject.layer == 16)
        {
            Destroy(gameObject);
        }
    }
}
