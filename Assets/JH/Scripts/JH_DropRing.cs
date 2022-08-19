using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * 부모 Ring *
// 1. 일반
// 플레이어와 닿이면 사라지게 하고 싶다.

// 2. 부스터
// 플레이어와 일정 거리 안에 있고, 플레이어가 부스터 상태이면 플레이어 쪽으로 이동하고 싶다.

// 3. 점수
// 링이 플레이어와 닿으면 +1

// * 자식 DropRing *
// 바닥과 닿으면 튕긴다.
// 일정 시간이 지나면 깜빡거린다.
// 일정 시간이 지나면 없어진다.

public class JH_DropRing : JH_Ring
{
    // 3초동안 그대로 있다가 2초동안 깜빡이고, 5초가 되면 사라지고 싶다.
    public float blinkTime = 2f;
    public float liveTime = 7f;
    float currentTime = 0f;

    MeshRenderer mesh;
    Vector3 pos;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        mesh = GetComponent<MeshRenderer>();
        StartCoroutine(IeBlink());
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        currentTime += Time.deltaTime;

        if (currentTime > liveTime)
        {
            StopCoroutine(IeBlink());
            Destroy(gameObject);
        }
        if (GetComponent<Collider>().isTrigger)
        {
            transform.position = pos;

        }
    }

    IEnumerator IeBlink()
    {
        yield return new WaitForSeconds(4f);

        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            mesh.enabled = false;
            yield return new WaitForSeconds(0.1f);
            mesh.enabled = true;
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag.Contains("Road"))
    //    {
    //        pos.y = other.gameObject.transform.position.y;
    //    }
    //}
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Road"))
        {
            ContactPoint contact = collision.contacts[0];

            pos.y = contact.point.y + 0.5f;
            GetComponent<Collider>().isTrigger = true;
        }
    }
}
