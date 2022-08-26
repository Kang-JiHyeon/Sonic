using System;
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
    GameObject target;
    public NK_Booster player;
    public float speed = 10f;
    public float boosterDis = 20f;
    float followTime = 1f;
    float curTime = 0f;
    
    // 링 회전
    public float rotationSpeed;
    public AudioSource collectSound;
    public GameObject collectEffect;

    // Start is called before the first frame update
    public virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        // Player의 스크립트를 가져온다.
        player = target.GetComponent<NK_Booster>();

        collectSound = GetComponent<AudioSource>();
    }

    bool isFollow = false;
    // Update is called once per frame
    public virtual void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        Follow();

    }

    private void Follow()
    {
        // 플레이어와 일정 거리 안에 있고, 플레이어가 부스터 상태이면 플레이어 쪽으로 이동하고 싶다.
        if (NK_Booster.Instance.isBooster && Vector3.Distance(transform.position, target.transform.position) < boosterDis)
        {
            // 일정 시간동안만 따라가게 하고 싶다.
            isFollow = true;

            curTime += Time.deltaTime;

            if (curTime > followTime)
            {
                isFollow = false;
            }

            if (isFollow)
            {
                transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);

                if (Vector3.Distance(transform.position, target.transform.position) < 1f)
                {
                    // 점수 증가
                    JH_Score.Instance.SCORE++;

                    collectSound.Play();
                    GetComponent<MeshRenderer>().enabled = false;
                    Invoke("OnDestroy", 0.2f);
                }
            }
        }
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void Collect()
    {
        if (collectSound)
            collectSound.Play();
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            // 플레이어와 닿으면 점수를 +1 하고 사라지고 싶다.
            if (other.gameObject.name.Contains("Player"))
            {
                Collect();

                if (!player.isBooster)
                {
                    // 점수 증가
                    JH_Score.Instance.SCORE++;
                    // 제거
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Invoke("OnDestroy", 0.2f);
                }
            }
        }
    }
}
