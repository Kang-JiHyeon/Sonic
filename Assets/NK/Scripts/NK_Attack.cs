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
    Animator anim;
    float currentTime = 0;
    float shortDistance;
    bool isAiming = false;
    bool isAttack = false;
    GameObject aim;

    public static NK_Attack Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        shortDistance = float.MaxValue;

        enemy = enemys[0];

        aim = Instantiate(aimFactory);
        aim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            Initialization();
            if (enemys.Count > 0)
            {
                SortEnemy();
            }
            return;
        }

        if (isAttack)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isAttack)
            {
                return;
            }

            SortEnemy();

            if (!isAiming)
            {
                aim.transform.position = enemy.transform.position + new Vector3(0, 1.5f, 0);
                aim.transform.forward = enemy.transform.forward;
                aim.SetActive(true);
                isAiming = true;
            }
            else
            {
                anim.SetBool("IsAttack", true);
                if (currentTime < attackTime)
                {
                    isAttack = true;
                }
                else
                {
                    Initialization();
                }
            }
        }

        if (isAiming)
        {
            currentTime += Time.deltaTime;
        }
    }

    public void Initialization()
    {
        currentTime = 0;
        isAiming = false;
        isAttack = false;
        aim.SetActive(false);
        anim.SetBool("IsAttack", false);
    }

    private void Attack()
    {
        aim.SetActive(false);
        Vector3 dir = aim.transform.position - transform.position;
        cc.Move(dir * attackSpeed * Time.deltaTime);
        enemys.Remove(enemy);
    }

    private void SortEnemy()
    {
        shortDistance = float.MaxValue;

        if (enemy == null)
        {
            enemy = enemys[0];
        }

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
