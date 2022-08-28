using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. �Ϲ�
// �÷��̾��� ���̸� �������� �ϰ� �ʹ�.

// 2. �ν���
// �÷��̾��� ���� �Ÿ� �ȿ� �ְ�, �÷��̾ �ν��� �����̸� �÷��̾� ������ �̵��ϰ� �ʹ�.

// 3. ����
// ���� �÷��̾��� ������ +1
public class JH_Ring : MonoBehaviour
{
    GameObject target;
    public NK_Booster player;
    public float speed = 10f;
    public float boosterDis = 20f;
    float followTime = 1f;
    float curTime = 0f;

    // �� ȸ��
    public float rotationSpeed;
    AudioSource collectSound;
    public GameObject collectEffect;

    // Start is called before the first frame update
    public virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        // Player�� ��ũ��Ʈ�� �����´�.
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
        // �÷��̾��� ���� �Ÿ� �ȿ� �ְ�, �÷��̾ �ν��� �����̸� �÷��̾� ������ �̵��ϰ� �ʹ�.
        if (NK_Booster.Instance.isBooster && Vector3.Distance(transform.position, target.transform.position) < boosterDis)
        {
            // ���� �ð����ȸ� ���󰡰� �ϰ� �ʹ�.
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
                    // ���� ����
                    JH_Score.Instance.SCORE++;
                    NK_ScoreManager.scoreManager.sumScore += 2000;

                    collectSound.Play();
                    GetComponent<MeshRenderer>().enabled = false;
                    Destroy(gameObject, 0.2f);
                }
            }
        }
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
            if (other.gameObject.name.Contains("Player"))
            {
                Collect();

                if (!player.isBooster)
                {
                    JH_Score.Instance.SCORE++;
                    NK_ScoreManager.scoreManager.sumScore += 2000;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Destroy(gameObject, 0.2f);
                }
            }
        }
    }
}
