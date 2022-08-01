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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            foreach (GameObject coin in coins)
            {
                coin.transform.position = transform.position;
                coin.SetActive(true);
                coin.transform.position += Vector3.back * 1f * Time.deltaTime;
            }
        }
    }
}
