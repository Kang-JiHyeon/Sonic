using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �÷��̾ �����Ǹ� ī�޶� Ŀ�� ���� ��ȯ�ϰ� �ʹ�.
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
