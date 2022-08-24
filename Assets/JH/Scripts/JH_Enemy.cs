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
    GameObject target;
    NK_Booster player;
    Vector3 dir;
    Vector3 originPos;

    public GameObject explosionFactory;
    public GameObject hitFactory;
    public float moveDis = 15f;
    public float angleY = 0.2f;
    public float boosterRange = 5f;
    public float speed = 50f;
    bool isHit = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        // 튕기기 전 위치
        originPos = transform.position;
        target = GameObject.Find("Player");
        player = target.GetComponent<NK_Booster>();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 일반 상태이면 플레이어가 부딪혀도 가만히 있고 싶다.

        // 플레이어가 공격 상태일 때 부딪히면
        if (isHit)
        {
            // 일정 거리 날라간 후 없어지고 싶다.
            if (Vector3.Distance(originPos, transform.position) > moveDis)
            {
                NK_Attack.Instance.enemys.Remove(gameObject);
                isHit = false;

                // 폭발 이펙트
                GameObject explosion = Instantiate(explosionFactory);
                explosion.transform.position = transform.position;
                Destroy(gameObject);
            }
        }
;
        // 2. 부스터
        // 플레이어가 부스터를 쓰고 있고, 적과 일정 거리 안이면 날라가고 싶다.
        // NK_Booster의 isBooster 대체
        if (player.isBooster)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < boosterRange)
            {
                Hit();
            }
        }
    }
    private void Hit()
    {
        // 적의 공격 당함 상태를 true로 만든다.
        isHit = true;

        if (target)
        {
            // 적이 튕겨나갈 방향을 구하고 싶다.
            // 플레이어의 앞방향을 구한다.
            dir = target.transform.forward;
            // y의 값만 변경한다.
            dir.y = angleY;
            dir.Normalize();
            // dir 방향으로 힘을 가한다.
            rigid.velocity = dir * speed;

            JH_CameraShack.Instance.PlayCameraShake();


        }
    }
    //player와 부딪히면 player의 이동방향+윗쪽으로 이동하고 싶다.
    //일정 거리 이상 날라가면 없어지고 싶다.
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 대상이 Player이면
        if (other.gameObject.name.Contains("Player") && !isHit)
        {
            if (NK_Attack.Instance.isAttack)
            {
                // hit 이펙트
                GameObject hit = Instantiate(hitFactory);
                hit.transform.position = transform.position + new Vector3(0, 1.5f, 0);
                Hit();

                //JH_CameraShack.Instance.PlayCameraShake();

            }
            else
            {
                NK_PlayerDamage.Instance.isDamage = true;
            }
        }

        // 맵이랑 닿이면 없애고 싶다.
        if (other.gameObject.layer == 16)
        {
            // 폭발 이펙트
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
