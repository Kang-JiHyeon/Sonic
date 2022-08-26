using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Attack : MonoBehaviour
{
    public List<GameObject> enemys;
    public GameObject enemy;
    public GameObject aimFactory;
    public GameObject attackFactory;
    public TrailRenderer trailRenderer;
    public float attackTime = 3;
    public float attackSpeed = 20;
    public bool isAttack = false;
    public bool isAiming = false;

    CharacterController cc;
    Animator anim;
    float currentTime = 0;
    float shortDistance;
    GameObject aim;
    GameObject attack;


    // Aim Sound Effect
    AudioSource aimSound;

    

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
        attack = Instantiate(attackFactory);
        attack.SetActive(false);

        aimSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        attack.transform.position = transform.position + new Vector3(0, 1, 0);
        anim.SetBool("IsAttack", isAttack);

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
            currentTime += Time.deltaTime;
            //gameObject.GetComponent<NK_PlayerMove>().enabled = false;
            if (currentTime < attackTime)
                Attack();
            else
                Initialization();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isAttack)
            {
                return;
            }

            SortEnemy();

            if (IsTargetVisible(Camera.main, enemy.transform))
            {
                if (!isAiming)
                {
                    aim.transform.position = enemy.transform.position + new Vector3(0, 1.5f, 0);
                    aim.transform.forward = enemy.transform.forward;
                    if (enemy.name.Contains("Bee"))
                        aim.transform.Rotate(0, 90, 0);
                    aim.SetActive(true);
                    aimSound.Play();
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
                        Initialization();
                    }
                }
            }
        }

        if (isAiming)
        {
            currentTime += Time.deltaTime;
            dir = aim.transform.position - transform.position;

            if (currentTime > attackTime)
            {
                isAiming = false;
                Initialization();
                currentTime = 0;
            }
        }
    }

    public void Initialization()
    {
        currentTime = 0;
        isAiming = false;
        isAttack = false;
        aim.SetActive(false);
        attack.SetActive(false);
        trailRenderer.enabled = false;
    }

    public Vector3 dir;
    private void Attack()
    {
        aim.SetActive(false);
        attack.SetActive(true);
        dir = aim.transform.position - transform.position;
        trailRenderer.enabled = true;
        cc.Move(dir * attackSpeed * Time.deltaTime);
        enemys.Remove(enemy);
        // gameObject.GetComponent<NK_PlayerMove>().enabled = true;
    }

    #region // �÷��̾ �Ÿ� ������ ������ �� ����
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
    #endregion


    #region // ī�޶� ȭ�� �ȿ� ���� �ִ��� ���� �Ǵ�
    bool IsTargetVisible(Camera cam, Transform tran)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(cam);
        var point = tran.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
                return false;
        }
        return true;
    }
    #endregion
}
