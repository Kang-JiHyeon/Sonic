using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerCollision : MonoBehaviour
{
    public GameObject coinFactory;
    public float damageTime = 0.5f;
    public bool isDamage;

    CharacterController cc;
    Animator anim;
    float currentTime = 0;
    int coinCount;

    public static NK_PlayerCollision Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        anim.SetBool("IsDamage", isDamage);

        if (isDamage)
        {
            gameObject.GetComponent<NK_PlayerMove>().enabled = false;
            Vector3 dir = -transform.forward;
            cc.SimpleMove(dir * 5);

            currentTime += Time.deltaTime;
            if (currentTime > damageTime)
            {
                gameObject.GetComponent<NK_PlayerMove>().enabled = true;
                isDamage = false;
                coinCount = 0;
                currentTime = 0;
            }

            if (coinCount < 10)
            {
                GameObject coin = Instantiate(coinFactory);
                coin.SetActive(false);
                coin.transform.position = transform.position + new Vector3(Random.Range(-3, 3), 1, Random.Range(-3, 3));
                coin.SetActive(true);
                coinCount++;

            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigid = hit.collider.gameObject.GetComponent<Rigidbody>();

        if (rigid && (!NK_Attack.Instance.isAttack && !NK_Booster.Instance.isBooster))
        {
            if (rigid.CompareTag("Wall") || isDamage)
            {
                anim.SetBool("IsDamage", true);
                Vector3 dir = transform.position - rigid.gameObject.transform.position;
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
}
