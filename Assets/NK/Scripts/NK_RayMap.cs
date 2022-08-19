using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_RayMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos1 = transform.position;
        Vector3 dir = -transform.up;//new Vector3(0, -1, 0);
        float maxDis = 1;

        // ���� ��ǥ�� �������� �Ʒ��� Ray�� ���.
        if (Physics.Raycast(pos1, dir, out RaycastHit raycastHit, maxDis))
        {
            Debug.Log($"�浹 {raycastHit.transform.name}");


            // �浹�� ������ ĳ������ ������ �����
            Vector3 incomingVec = raycastHit.point - this.transform.position;

            // ������� ���ΰ� �浹�� ���� Normal�� ������ �ݻ簪�� ������.
            // �߷��� �����Ǿ��ٸ�  raycastHit.normal �� ������ ��縦 �����Ҽ��� ������ ����..
            Vector3 reflectVec = Vector3.Reflect(incomingVec, raycastHit.normal);
            Vector3 currentFo = transform.forward;
            transform.up = raycastHit.normal;//reflectVec;
            transform.forward = currentFo;


            // Draw lines to show the incoming "beam" and the reflection.
            Debug.DrawLine(this.transform.position, raycastHit.point, Color.red, 0.3f);
            Debug.DrawRay(raycastHit.point, reflectVec, Color.green, 0.3f);
        }
    }
}
