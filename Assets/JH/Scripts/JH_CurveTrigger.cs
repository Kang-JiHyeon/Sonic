using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 플레이어가 감지되면 카메라를 커브 모드로 전환하고 싶다.
public class JH_CurveTrigger : MonoBehaviour
{
    float curveCount = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player")){

            curveCount++;

            if(curveCount < 2f)
            {
                //JH_CamManager.Instance.isCurve = true;
            }
            else
            {
                //JH_CamManager.Instance.isCurve = false;
                curveCount = 0f;
            }
            print("Trigger!!");
        }
    }
}
