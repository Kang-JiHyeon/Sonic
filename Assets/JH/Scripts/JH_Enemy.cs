using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ű�� ������ ���� �밢������ �����Ÿ� ���󰡰� �ʹ�.
// �ʿ�Ӽ� : �̵� ����, �̵� �Ÿ�, �ӵ�, ����
public class JH_Enemy : MonoBehaviour
{
    // �̵� ����, �̵� �Ÿ�
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
        //// ���� �밢�� ���������� �̵��ϰ� �ʹ�.
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

    // player�� �ε��� ������ �밢�� ���� �̵��ϰ� �ʹ�.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            ContactPoint cp = collision.GetContact(0);
            
            print(cp.point);

            dir = transform.position - cp.point; // ���������������� ź��ġ �� ����
            dir += new Vector3(0, angleY, 0);
            dir.Normalize();

            isHit = true;
        }
    }
}
