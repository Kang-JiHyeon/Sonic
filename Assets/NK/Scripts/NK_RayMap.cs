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

        // 현재 좌표를 기준으로 아래로 Ray를 쏜다.
        if (Physics.Raycast(pos1, dir, out RaycastHit raycastHit, maxDis))
        {
            Debug.Log($"충돌 {raycastHit.transform.name}");


            // 충돌한 지점과 캐릭터의 라인을 만든다
            Vector3 incomingVec = raycastHit.point - this.transform.position;

            // 만들어진 라인과 충돌된 곳의 Normal을 가지고 반사값을 만들자.
            // 중력이 고정되었다면  raycastHit.normal 만 가지고도 경사를 측정할수도 있을꺼 같다..
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
