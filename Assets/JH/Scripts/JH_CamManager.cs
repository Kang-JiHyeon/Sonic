using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 움직임을 따라가고 싶다.
// 필요속성: 플레이어
public class JH_CamManager : MonoBehaviour
{
    JH_PlayerMove player;
    public Vector3 offset;
    Vector3 dir;
    float dirX, dirY;
    float spinSpeed = 2f;
    // Start is called before the first frame update
    public static JH_CamManager Instance;


    //public Transform curvePos;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<JH_PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

    }
}

// 커브 트리거 발동 -> CamManager 회전
