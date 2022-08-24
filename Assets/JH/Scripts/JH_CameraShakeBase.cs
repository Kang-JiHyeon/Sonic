using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� ����ũ�� ������ �� �ִ� ���� ���� ����ü
[System.Serializable]
public struct CameraShakeInfo
{
    public float amplitude;
    public float sinSpeed;
}

// ��� ī�޶����ũ Ŭ������ �θ� Ŭ����
public class JH_CameraShakeBase : MonoBehaviour
{
    // ī�޶��� �ʱ���ġ ���
    protected Vector3 originPos;

    public virtual void Init(Vector3 originPos)
    {
        this.originPos = originPos;
    }

    // ī�޶����ũ ���
    // trasform: ī�޶� ����ũ �� ī�޶��� Ʈ������
    // info : ����ڰ� ������ ī�޶� ����ũ ����
    public virtual void Play(Transform transform, CameraShakeInfo info)
    {

    }


    // ī�޶����ũ ����
    // trasform: ī�޶� ����ũ �� ī�޶��� Ʈ������
    public virtual void Stop(Transform transform)
    {

    }
}
