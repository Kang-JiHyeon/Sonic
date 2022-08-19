using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �� ������Ʈ�� ī�޶� ��ġ ���صΰ�, Ÿ�� ���� ���ؼ� ī�޶� ������ lerp�� �̵�����! (ī�޶� ȸ���� ���Ŀ�..?)
// ī�޶� ��ġ�� ����� �� ī�޶��� forward ������ Ÿ���� �������� �����Ѵ�.


// 1. �Ϲ�
// CamPos1�� ��ġ�ϰ� �ʹ�.
// �÷��̾ ���󰡰� �ʹ�. foward = z��

// 2. �ν���
// �Ϲݺ��� ���� �� ����

// 2. Ⱦ��ũ��
// ī�޶��� ���� ������ �÷��̾ ������ �ϵ� �����Ӱ�... foward = -x��
public class JH_Camera : MonoBehaviour
{
    public Vector3 offset;
    GameObject player;
    // �Ϲ�
    public Transform camPos1;
    public float camMoveSpeed = 0.7f;
    // ��
    public Transform camPos2;

    public bool isHorizontal = false;  // Horizontal
    public bool isCamMove = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = camPos1.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // camPos1�� ��ġ�� �̵��ϰ� �ʹ�.
        if (!isHorizontal)
        {
            transform.position = Vector3.Lerp(transform.position, camPos1.position, Time.deltaTime * camMoveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, camPos1.rotation, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(transform.position, camPos1.position) < 0.1f)
            {
                transform.position = camPos1.position;
                transform.rotation = camPos1.rotation;
            }
        }
        
        // camPos2�� ��ġ�� �̵��ϰ� �ʹ�.
        if (isHorizontal && isCamMove)
        {
            transform.position = Vector3.Lerp(transform.position, camPos2.position, Time.deltaTime * camMoveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, camPos2.rotation, Time.deltaTime * camMoveSpeed);

            if (Vector3.Distance(transform.position, camPos2.position) < 0.1f)
            {
                transform.position = camPos2.position;
                transform.rotation = camPos2.rotation;
                isCamMove = false;
            }
        }
    }
}
