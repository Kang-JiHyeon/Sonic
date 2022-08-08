using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ �ν��� ���� �������� �ν��� ���·� �����ϰ� �ʹ�.
public class JH_BoosterBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ �����Ǹ�
        if (other.gameObject.name.Contains("Player"))
        {
            // �÷��̾��� �ν��� ���¸� true�� �����ϰ� �ʹ�.
            other.GetComponent<NK_Booster>().isBooster = true;
        }
    }
}
