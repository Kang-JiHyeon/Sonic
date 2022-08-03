using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PlayerMove : MonoBehaviour
{
    Vector3 dir;
    public bool isAttack = false;
    public GameObject target;
    float speed = 10f;
    float boosterSpeed = 30f;

    // NK_Booster의 isBooster 대체
    public bool isBooster;
    public bool isHorMode;


    // Start is called before the first frame update
    void Start()
    {
        dir = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        if (isHorMode)
        {

            dir = Vector3.forward * h + Vector3.left * v;
        }
        else
        {
            dir = Vector3.right * h + Vector3.forward * v;
        }

        dir.Normalize();

        if (h != 0 || v != 0)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            if (isBooster)
            {
                transform.position += dir * boosterSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += dir * speed * Time.deltaTime;
            }
        }

    }

}

// 타겟이 오는 방향을 받아서 그방향 + 위로 가는 방향해서 해보기!!!
