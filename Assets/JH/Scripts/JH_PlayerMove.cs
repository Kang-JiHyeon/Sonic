using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PlayerMove : MonoBehaviour
{
    Vector3 dir;
    public bool isAttack = false;
    public GameObject target;
    JH_Enemy enemy;
    Vector3 targetDir;

    // NK_Booster�� isBooster ��ü
    public bool isBooster;


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

        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        if (h != 0 || v != 0)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            transform.position += dir * 10f * Time.deltaTime;
        }

    }

}

// Ÿ���� ���� ������ �޾Ƽ� �׹��� + ���� ���� �����ؼ� �غ���!!!
