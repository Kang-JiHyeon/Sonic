using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Attack : MonoBehaviour
{
    public List<GameObject> enemys;
    public GameObject enemy;
    public GameObject aimFactory;
    public float attackTime = 2;

    float currentTime = 0;
    float shortDistance;
    bool isAiming = false;
    GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        shortDistance = Vector3.Distance(gameObject.transform.position, enemys[0].transform.position);

        enemy = enemys[0];

        aim = Instantiate(aimFactory);
        aim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject e in enemys)
        {
            float distance = Vector3.Distance(gameObject.transform.position, e.transform.position);

            if (distance < shortDistance)
            {
                enemy = e;
                shortDistance = distance;
            }
        }

        if (isAiming && aim != null)
        {
            if (currentTime < attackTime)
            {
                NK_PlayerJump.Instance.Jump();
                Vector3 dir = enemy.transform.position - transform.position;
                dir.Normalize();
                transform.position += dir * 5f * Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Destroy(enemy);
                    isAiming = false;
                    aim.SetActive(false);
                }
                currentTime = 0;
            }
            else
            {
                currentTime = 0;
                isAiming = false;
                aim.SetActive(false);
            }
            currentTime += Time.deltaTime;
        }

        if (!isAiming && Input.GetKeyDown(KeyCode.S))
        {
            aim.transform.position = enemy.transform.position;
            aim.SetActive(true);
            isAiming = true;
        }
    }
}
