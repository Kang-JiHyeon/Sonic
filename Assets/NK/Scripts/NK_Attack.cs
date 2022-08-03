using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Attack : MonoBehaviour
{
    public List<GameObject> enemys;
    public GameObject enemy;
    public GameObject aimFactory;
    public float attackTime = 2;
    public float attackSpeed = 20;

    CharacterController cc;
    float currentTime = 0;
    float shortDistance;
    bool isAiming = false;
    bool isAttack = false;
    GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

        enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        shortDistance = Vector3.Distance(gameObject.transform.position, enemys[0].transform.position);

        enemy = enemys[0];

        aim = Instantiate(aimFactory);
        aim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemys.Count <= 0 && enemys != null)
        {
            return;
        }

        if (isAttack)
        {
            Attack();
        }

        SortEnemy();

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isAiming)
            {
                aim.transform.position = enemy.transform.position;
                aim.SetActive(true);
                isAiming = true;
            }
            else
            {
                if (currentTime < attackTime)
                {
                    isAttack = true;
                }
                else
                {
                    currentTime = 0;
                    isAiming = false;
                    isAttack = false;
                    aim.SetActive(false);
                }
                currentTime += Time.deltaTime;
            }
        }
    }

    private void Attack()
    {
        Vector3 dir = enemy.transform.position - transform.position;
        cc.Move(dir * attackSpeed * Time.deltaTime);
    }

    private void SortEnemy()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, enemys[i].transform.position);

            if (distance < shortDistance)
            {
                enemy = enemys[i];
                shortDistance = distance;
            }
        }
    }
}
