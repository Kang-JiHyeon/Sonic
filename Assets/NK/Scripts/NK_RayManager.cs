using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_RayManager : MonoBehaviour
{
    CharacterController controller;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float maxDis = 1;

        // ���� ��ǥ�� �������� �Ʒ��� Ray�� ����.
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit raycastHit, maxDis))
        {
            if ((raycastHit.collider.CompareTag("Road") && Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal) || raycastHit.collider.CompareTag("ShuckShuck"))
            {
                dir = new Vector3(transform.position.x, transform.position.y, raycastHit.transform.position.z) - transform.position;
                controller.SimpleMove(dir);
            }

            if (raycastHit.collider.CompareTag("ShuckShuck"))
            {
                NK_PlayerMove.Instance.isShuckShuck = true;
                GetComponent<NK_ShuckShuck>().enabled = true;
            }
        }

        maxDis = 20;

        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), -transform.right, out RaycastHit raycastHit2, maxDis))
        {
            if (raycastHit2.collider.CompareTag("Guard") && NK_PlayerMove.Instance.isShuckShuck)
            {
                print(raycastHit2.transform.name);
                NK_ShuckShuck.Instance.movements[0] = raycastHit2.point - new Vector3(0, 1, 0);
                Debug.DrawLine(this.transform.position, raycastHit2.point, Color.red, maxDis);
            }
        }

        if (Physics.Raycast(transform.position + new Vector3(0,1,0), transform.right, out RaycastHit raycastHit3, maxDis))
        {
            if (raycastHit3.collider.CompareTag("Guard") && NK_PlayerMove.Instance.isShuckShuck)
            {
                print(raycastHit3.transform.name);
                NK_ShuckShuck.Instance.movements[2] = raycastHit3.point - new Vector3(0, 1, 0);
                NK_ShuckShuck.Instance.movements[1] = (NK_ShuckShuck.Instance.movements[0] + NK_ShuckShuck.Instance.movements[2]) / 2;
                Debug.DrawLine(this.transform.position, raycastHit3.point, Color.red, maxDis);
            }
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.forward, out RaycastHit raycastHit4, maxDis))
        {
            if (raycastHit4.collider.CompareTag("CurveOut"))
            {
                NK_PlayerMove.Instance.isShuckShuck = false;
            }
        }
    }
}
