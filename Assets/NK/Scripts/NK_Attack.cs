using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Attack : MonoBehaviour
{
    public List<GameObject> enemys;
    public GameObject enemy;
    float shortDistance;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
    }
}
