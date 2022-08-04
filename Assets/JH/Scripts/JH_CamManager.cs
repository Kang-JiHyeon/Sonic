using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 움직임을 따라가고 싶다.
// 필요속성: 플레이어
public class JH_CamManager : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어를 따라 움직인다.
        transform.position = player.transform.position + new Vector3(0, 0, -3);
        //transform.forward = player.transform.forward;
        //transform.LookAt(player.transform.position);
        transform.rotation = Quaternion.LookRotation(player.transform.forward);
    }
}
