using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_RayManager : MonoBehaviour
{
    public float gravity = 50;

    CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos1 = transform.position;
        Vector3 dir = -transform.up;//new Vector3(0, -1, 0);
        float maxDis = 1;

        // ���� ��ǥ�� �������� �Ʒ��� Ray�� ����.
        if (Physics.Raycast(pos1, dir, out RaycastHit raycastHit, maxDis))
        {
            if (raycastHit.collider.CompareTag("Road") && Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal)
            {
                dir = new Vector3(transform.position.x, transform.position.y, raycastHit.transform.position.z) - transform.position;
                controller.SimpleMove(dir);
            }

/*            // �浹�� ������ ĳ������ ������ ������
            Vector3 incomingVec = raycastHit.normal + transform.forward;
            if (raycastHit.collider.CompareTag("Incline"))
            {
                Debug.Log($"�浹 {raycastHit.transform.position}");
                dir = new Vector3(transform.position.x, transform.position.y, raycastHit.transform.position.z) - transform.position;
                controller.SimpleMove(dir);
                Vector3 CrossVec = Vector3.Cross(incomingVec, raycastHit.normal);
                //Vector3 DotVec = Vector3.Dot(incomingVec, raycastHit.normal);
                Vector3 reflectVec = Vector3.Reflect(incomingVec, raycastHit.normal);
                Debug.DrawLine(transform.position, incomingVec, Color.red, 0.3f);
*/
                // �������� ���ΰ� �浹�� ���� Normal�� ������ �ݻ簪�� ������.
                // �߷��� �����Ǿ��ٸ�  raycastHit.normal �� �������� ���縦 �����Ҽ��� ������ ����..
                /*Vector3 reflectVec = Vector3.Reflect(incomingVec, raycastHit.normal);
                transform.up = raycastHit.normal;

                NK_PlayerMove.Instance.dir -= raycastHit.normal * gravity * Time.deltaTime;

                Debug.DrawLine(this.transform.position, raycastHit.point, Color.red, 0.3f);
                Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.green, 0.3f);*/
/*            }*/
        }
    }
}
