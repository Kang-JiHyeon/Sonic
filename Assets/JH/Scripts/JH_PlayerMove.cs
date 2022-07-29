using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// s Ű�� ������ Ÿ������ �̵��ϰ� �ʹ�.
public class JH_PlayerMove : MonoBehaviour
{
    public Vector3 dir;
    public bool isAttack = false;
    public GameObject target;
    JH_Enemy enemy;
    Vector3 targetDir;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetDir = target.transform.position - transform.position;
            targetDir.Normalize();
            isAttack = true;
        }

        else if (h != 0 || v != 0)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            transform.position += dir * 10f * Time.deltaTime;
        }
        if (isAttack)
        {
            Vector3.MoveTowards(transform.position, target.transform.position, 10f);
        }
    }

}

// Ÿ���� ���� ������ �޾Ƽ� �׹��� + ���� ���� �����ؼ� �غ���!!!
