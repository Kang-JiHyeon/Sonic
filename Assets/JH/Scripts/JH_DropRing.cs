using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * �θ� Ring *
// 1. �Ϲ�
// �÷��̾�� ���̸� ������� �ϰ� �ʹ�.

// 2. �ν���
// �÷��̾�� ���� �Ÿ� �ȿ� �ְ�, �÷��̾ �ν��� �����̸� �÷��̾� ������ �̵��ϰ� �ʹ�.

// 3. ����
// ���� �÷��̾�� ������ +1

// * �ڽ� DropRing *
// �ٴڰ� ������ ƨ���.
// ���� �ð��� ������ �����Ÿ���.
// ���� �ð��� ������ ��������.

public class JH_DropRing : JH_Ring
{
    // 3�ʵ��� �״�� �ִٰ� 2�ʵ��� �����̰�, 5�ʰ� �Ǹ� ������� �ʹ�.
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
