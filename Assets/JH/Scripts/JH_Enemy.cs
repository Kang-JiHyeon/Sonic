using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. �Ϲ�
// �÷��̾�� �ε����� �÷��̾� �̵� ���� + �������� �����Ÿ� ���󰡰� �ʹ�.
// �ʿ�Ӽ� : �̵� ����, �̵� �Ÿ�, �ӵ�, ����

// 2. �ν���
// �÷��̾ �ν��͸� ���� �ְ�, ���� ���� �Ÿ� ���̸� ���󰡰� �ʹ�.


// 3. ��
// ���̶� ������ �������� �ʹ�.
public class JH_Enemy : MonoBehaviour
{
    // �̵� ����, �̵� �Ÿ�
    Rigidbody rigid;
    NK_Booster player;
    GameObject target;
    GameObject robot;
    Vector3 dir;
    Vector3 originPos;

    public AudioSource hitSound1;
    public AudioSource hitSound2;
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
        robot = transform.GetChild(1).gameObject;
        rigid = GetComponent<Rigidbody>();
        // ƨ��� �� ��ġ
        originPos = transform.position;
        target = GameObject.FindGameObjectWithTag("Player");

        player = target.GetComponent<NK_Booster>();
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾ �Ϲ� �����̸� �÷��̾ �ε����� ������ �ְ� �ʹ�.

        // �÷��̾ ���� ������ �� �ε�����
        if (isHit)
        {
            // ���� �Ÿ� ���� �� �������� �ʹ�.
            if (Vector3.Distance(originPos, transform.position) > moveDis)
            {

                NK_Attack.Instance.enemys.Remove(gameObject);
                isHit = false;

                // ���� ����Ʈ
                GameObject explosion = Instantiate(explosionFactory);
                explosion.transform.position = transform.position;

                robot.SetActive(false);

                // �ǰ� ���� ���
                PlayHit(hitSound2);

                //if (!JH_SoundManager.Instance.audioSourceDic["EnemyHit2"].isPlaying)
                //{
                //    JH_SoundManager.Instance.PlaySound("EnemyHit2");
                //    Destroy(gameObject, 0.5f);
                //}
            }
        }
        // 2. �ν���
        // �÷��̾ �ν��͸� ���� �ְ�, ���� ���� �Ÿ� ���̸� ���󰡰� �ʹ�.
        // NK_Booster�� isBooster ��ü
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
        // ���� ���� ���� ���¸� true�� �����.
        isHit = true;

        if (target)
        {
            // ���� ƨ�ܳ��� ������ ���ϰ� �ʹ�.
            // �÷��̾��� �չ����� ���Ѵ�.
            dir = target.transform.forward;
            // y�� ���� �����Ѵ�.
            dir.y = angleY;
            dir.Normalize();
            // dir �������� ���� ���Ѵ�.
            rigid.velocity = dir * speed;
            NK_ScoreManager.scoreManager.sumScore += 3000;

            // �ǰ� ���� ���
            PlayHit(hitSound1);

            JH_CameraShack.Instance.PlayCameraShake();
        }
    }
    //player�� �ε����� player�� �̵�����+�������� �̵��ϰ� �ʹ�.
    //���� �Ÿ� �̻� ���󰡸� �������� �ʹ�.
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ����� Player�̸�
        if (other.gameObject.name.Contains("Player") && !isHit)
        {
            // �÷��̾ ���� ���̶��
            if (NK_Attack.Instance.isAttack)
            {
                // hit ����Ʈ
                GameObject hit = Instantiate(hitFactory);
                hit.transform.position = transform.position + new Vector3(0, 1.5f, 0);
                Hit();
                other.gameObject.GetComponentInChildren<Animator>().SetTrigger("AttackSuccess");
            }
            // �÷��̾ ���� ���� �ƴ϶��
            else
            {
                if (0 >= JH_Score.Instance.RING)
                {
                    NK_Life.LifeManager.Life--;
                }
                NK_PlayerDamage.Instance.isDamage = true;

                // �÷��̾� �ǰ� ���� ���
                JH_SoundManager.Instance.PlaySound("DropRing");

                // �÷��̾� �ǰ� ���� ���
                JH_SoundManager.Instance.PlaySound("PlayerHit");
            }
        }

        // ���̶� ���̸� ���ְ� �ʹ�.
        if (other.gameObject.layer == 16)
        {
            // ���� ����Ʈ
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;

            // �ǰ� ���� ���
            PlayHit(hitSound2);
        }
    }

    void PlayHit(AudioSource audio)
    {
        // �ǰ� ���� ���
        if (!audio.isPlaying)
        {
            audio.Play();
            if(audio == hitSound2)
                Destroy(gameObject, 0.3f);
        }
    }
}
