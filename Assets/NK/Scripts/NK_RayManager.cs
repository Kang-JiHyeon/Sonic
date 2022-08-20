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

        // 현재 좌표를 기준으로 아래로 Ray를 쏜다.
        if (Physics.Raycast(pos1, dir, out RaycastHit raycastHit, maxDis))
        {
            if (raycastHit.collider.CompareTag("Road") && Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal)
            {
                dir = new Vector3(transform.position.x, transform.position.y, raycastHit.transform.position.z) - transform.position;
                controller.SimpleMove(dir);
            }


            //raycastHit.transform.gameObject
            // 충돌한 지점과 캐릭터의 라인을 만든다
            Vector3 incomingVec = raycastHit.point - this.transform.position;
            if (raycastHit.collider.CompareTag("Incline"))
            {
                Debug.Log($"충돌 {raycastHit.transform.position}");
                dir = new Vector3(transform.position.x, transform.position.y, raycastHit.transform.position.z) - transform.position;
                controller.SimpleMove(dir);

                // 만들어진 라인과 충돌된 곳의 Normal을 가지고 반사값을 만들자.
                // 중력이 고정되었다면  raycastHit.normal 만 가지고도 경사를 측정할수도 있을꺼 같다..
                /*Vector3 reflectVec = Vector3.Reflect(incomingVec, raycastHit.normal);
                transform.up = raycastHit.normal;

                NK_PlayerMove.Instance.dir -= raycastHit.normal * gravity * Time.deltaTime;

                Debug.DrawLine(this.transform.position, raycastHit.point, Color.red, 0.3f);
                Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.green, 0.3f);*/
            }
        }
    }
}
