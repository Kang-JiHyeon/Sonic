using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 키를 누르면 뒷쪽 대각선으로 일정거리 날라가고 싶다.
// 필요속성 : 이동 방향, 이동 거리, 속도, 각도
public class JH_Enemy : MonoBehaviour
{
    // 이동 방향, 이동 거리
    Vector3 dir;
    Vector3 originPos;
    public float moveDis = 10f;
    public float speed = 15f;
    public float angleY = 0.5f;

    bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        //// 뒷쪽 대각선 윗방향으로 이동하고 싶다.
        //dir = -transform.forward + new Vector3(0, angleY, 0);
        //dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    isHit = true;
        //}

        if (isHit)
        {
            transform.position += dir * speed * Time.deltaTime;

            if(Vector3.Distance(originPos, transform.position) > moveDis)
            {
                Destroy(gameObject);
                isHit = false;
            }
        }
    }

    // player와 부딪힌 방향의 대각선 위로 이동하고 싶다.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            ContactPoint cp = collision.GetContact(0);
            
            print(cp.point);

            dir = transform.position - cp.point; // 접촉지점에서부터 탄위치 의 방향
            dir += new Vector3(0, angleY, 0);
            dir.Normalize();

            isHit = true;
        }
    }
}
