using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerCollision : MonoBehaviour
{
    public GameObject coinFactory;
    public int coinCount = 10;
    List<GameObject> coins = new List<GameObject>();

    private void Start()
    {
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
        if (rigid.CompareTag("Wall"))
        {
            foreach (GameObject coin in coins)
            {
                coin.transform.position = transform.position + new Vector3(0, 1, 0);
                coin.SetActive(true);
                coin.transform.position += Vector3.back * 1f * Time.deltaTime;
            }
        }
    }
}
