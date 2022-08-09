using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerCollision : MonoBehaviour
{
    public GameObject coinFactory;
    public int coinCount = 10;
    List<GameObject> coins = new List<GameObject>();
    CharacterController cc;
    Vector3 impact = Vector3.zero;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinFactory);
            coin.SetActive(false);
            coins.Add(coin);
        }
    }

    private void Update()
    {

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigid = hit.collider.gameObject.GetComponent<Rigidbody>();

        if (rigid)
        {
            if (rigid.CompareTag("Wall"))
            {
                Vector3 dir = transform.position - rigid.gameObject.transform.position;
                //AddImpact(dir, 5f);
                cc.SimpleMove(dir);
            
                foreach (GameObject coin in coins)
                {
                    coin.transform.position = transform.position + new Vector3(0, 2, 0);
                    coin.SetActive(true);
                    coin.transform.position += Vector3.up * 1f * Time.deltaTime;
                }
            }

            if (rigid.CompareTag("Enemy"))
            {
                rigid.gameObject.SetActive(false);
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
        //impact += dir.normalized * force / mass;
    }
}
