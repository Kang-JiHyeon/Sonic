using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �������� ���󰡰� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�
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
        // �÷��̾ ���� �����δ�.
        transform.position = player.transform.position;
    }
}
