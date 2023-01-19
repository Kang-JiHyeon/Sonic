using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ʒ��� ī�޶� ����ũ
public class JH_CameraShack : MonoBehaviour
{
    // ī�޶�
    Transform cam;
    // ī�޶� �ʱ� ��ġ
    Vector3 originPos;
    // ����
    public float amplitude = 0.2f;
    // �ֱ�
    public float sinSpeed = 1000f;
    // ����ð�
    public float playTime = 0.1f;
    float theta = 0;

    public static JH_CameraShack Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    void Start()
    {
        cam = Camera.main.transform;
    }
    void Update()
    {
        
    }

    public void PlayCameraShake()
    {
        StopAllCoroutines();
        StartCoroutine(IePlay());
    }

    IEnumerator IePlay()
    {
        // ����ŷ ���� ī�޶� ��ġ ����
        originPos = cam.position;

        float currentTime = 0;
        while(currentTime < playTime)
        {
            currentTime += Time.deltaTime;
            Play(cam);
            yield return null;
        }
        Stop(cam);
    }

    public void Play(Transform transform)
    {
        theta += sinSpeed * Time.deltaTime;
        transform.position = originPos + Vector3.up * Mathf.Sin(theta) * amplitude;
    }

    public void Stop(Transform transform)
    {
        transform.position = originPos;
        theta = 0f;
    }
}
