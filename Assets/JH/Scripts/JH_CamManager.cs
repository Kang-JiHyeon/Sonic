using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 움직임을 따라가고 싶다.
// 필요속성: 플레이어
public class JH_CamManager : MonoBehaviour
{
    JH_PlayerMove player;
    public Vector3 offset;
    float dirX, dirY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<JH_PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어를 따라 움직인다.
        transform.position = player.transform.position + offset;

        ////dirX = Mathf.Clamp(player.dir.x, -60, 60);
        //dirY = Mathf.Clamp(player.dir.y, -60, 60);
        //transform.rotation = Quaternion.LookRotation(new Vector3(player.dir.x, dirY, player.dir.z).normalized);
        //transform.LookAt(player.transform.position);
    }
}

// 커브 트리거 발동 -> CamManager 회전
