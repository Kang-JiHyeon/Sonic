using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �������� ���󰡰� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�
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
        // �÷��̾ ���� �����δ�.
        transform.position = player.transform.position + offset;

        ////dirX = Mathf.Clamp(player.dir.x, -60, 60);
        //dirY = Mathf.Clamp(player.dir.y, -60, 60);
        //transform.rotation = Quaternion.LookRotation(new Vector3(player.dir.x, dirY, player.dir.z).normalized);
        //transform.LookAt(player.transform.position);
    }
}

// Ŀ�� Ʈ���� �ߵ� -> CamManager ȸ��
