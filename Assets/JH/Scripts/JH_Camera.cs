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
    // ��
    public Transform camPos2;

    public bool isVertical = false;    // Vertical
    public bool isHorizontal = false;  // Horizontal

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 5, -9);
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

        // 1�� ������
        if (!isHorizontal)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                isVertical = true;
            }

        }
        if (!isVertical)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                isHorizontal = true;
            }
        }

            // camPos1�� ��ġ�� �̵��ϰ� �ʹ�.
            if (isVertical && !isHorizontal)
        {
            transform.position = Vector3.Lerp(transform.position, camPos1.position, Time.deltaTime * 2);
            transform.forward = player.transform.position - transform.position;
            if (Vector3.Distance(transform.position, camPos1.position) < 0.1f)
            {
                transform.position = camPos1.position;
                isVertical = false;
            }
        }

        // camPos2�� ��ġ�� �̵��ϰ� �ʹ�.
        if (isHorizontal && !isVertical)
        {
            transform.position = Vector3.Lerp(transform.position, camPos2.position, Time.deltaTime * 2);
            transform.forward = player.transform.position - transform.position;

            if (Vector3.Distance(transform.position, camPos2.position) < 0.1f)
            {
                transform.position = camPos2.position;
                isHorizontal = false;
            }
        }
    }
}
