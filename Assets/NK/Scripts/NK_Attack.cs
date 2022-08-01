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
    // Start is called before the first frame update
    void Start()
    {
        enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        shortDistance = Vector3.Distance(gameObject.transform.position, enemys[0].transform.position);

        enemy = enemys[0];

        foreach (GameObject e in enemys)
        {
            float distance = Vector3.Distance(gameObject.transform.position, e.transform.position);

            if (distance < shortDistance)
            {
                enemy = e;
                shortDistance = distance;
            }
        }

        Debug.Log(enemy.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAiming && Input.GetKeyDown(KeyCode.S))
        {
            GameObject aim = Instantiate(aimFactory);
            aim.transform.position = enemy.transform.position;
            isAiming = true;
        }

        if (isAiming)
        {
            if (currentTime < attackTime)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Destroy(enemy);
                }
                currentTime = 0;
                isAiming = false;
            }
            else
            {
                currentTime = 0;
                isAiming = false;
            }
            currentTime += Time.deltaTime;
        }
    }
}
