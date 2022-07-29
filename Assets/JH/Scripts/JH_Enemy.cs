using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 키를 누르면 뒷쪽 대각선으로 일정거리 날라가고 싶다.
// 필요속성 : 이동 방향, 이동 거리, 속도, 각도
public class JH_Enemy : MonoBehaviour
{
    // 이동 방향, 이동 거리
    Rigidbody rigid;
    JH_PlayerMove player;
    Vector3 dir;
    Vector3 originPos;
    public float moveDis;
    public float force;
    public float angleY;
    public bool isHit = false;


    // Start is called before the first frame update
    void Start()
    {
        // TEST
        rigid = GetComponent<Rigidbody>();
        // 튕기기 전 위치
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 공격을 받으면
        if (isHit)
        {
            // Player의 방향 설정 스크립트를 가져온다.
            player = GameObject.Find("Player").GetComponent<JH_PlayerMove>();
            // 적이 튕겨나갈 방향을 구한다.
            dir = new Vector3(player.dir.x, angleY, player.dir.z);
            dir.Normalize();

            // 적의 rigidbody컴포넌트
            rigid.AddForce(dir * force, ForceMode.Impulse);

            if (Vector3.Distance(originPos, transform.position) > moveDis)
            {
                Destroy(gameObject);
                isHit = false;
            }

        }
    }

    // player와 부딪히면 player의 이동방향+윗쪽으로 이동하고 싶다.
    // 일정 거리 이상 날라가면 없어지고 싶다.
    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 대상이 Player이면
        if (collision.gameObject.name.Contains("Player"))
        {
            // 적의 공격 당함 상태를 true로 만든다.
            isHit = true;
        }
    }
}
