using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �������� ���󰡰� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�
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

// Ŀ�� Ʈ���� �ߵ� -> CamManager ȸ��
