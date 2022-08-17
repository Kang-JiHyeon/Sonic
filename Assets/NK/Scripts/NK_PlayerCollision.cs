using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerCollision : MonoBehaviour
{
    public GameObject coinFactory;
    public int coinCount = 10;
    public float damageTime = 2;

    List<GameObject> coins = new List<GameObject>();
    CharacterController cc;
    Animator anim;
    float currentTime = 0;
    Vector3 impact = Vector3.zero;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinFactory);
            coin.SetActive(false);
            coin.GetComponent<SphereCollider>().enabled = false;
            coin.GetComponent<JH_Ring>().enabled = false;
            coins.Add(coin);
        }
    }

    private void Update()
    {
        if (anim.GetBool("IsDamage"))
        {
            currentTime += Time.deltaTime;
            if (currentTime > damageTime)
            {
                anim.SetBool("IsDamage", false);
                currentTime = 0;

                foreach (GameObject coin in coins)
                {
                    coin.GetComponent<SphereCollider>().enabled = true;
                    coin.GetComponent<JH_Ring>().enabled = true;
                }
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigid = hit.collider.gameObject.GetComponent<Rigidbody>();

        if (rigid && (!NK_Attack.Instance.isAttack && !NK_Booster.Instance.isBooster))
        {
            if (rigid.CompareTag("Wall") || rigid.CompareTag("Enemy"))
            {
                anim.SetBool("IsDamage", true);
                Vector3 dir = transform.position - rigid.gameObject.transform.position;
                AddImpact(dir, 5f);
                cc.SimpleMove(dir);

                GameObject coin = Instantiate(coinFactory);
                coin.SetActive(false);
                coin.transform.position = transform.position + new Vector3(Random.Range(-3, 3), 1, Random.Range(-3, 3));
                coin.SetActive(true);

                /*                foreach (GameObject coin in coins)
                                {
                                    coin.transform.position = transform.position + new Vector3(Random.Range(-3, 3), 1, Random.Range(-3,3));
                                    coin.SetActive(true);
                                    coin.transform.position += Vector3.up * 1f * Time.deltaTime;
                                }*/
            }
        }
    }

    void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0)
        {
            dir.y = -dir.y;
        }
        impact += dir.normalized * force / 2;
    }
}
