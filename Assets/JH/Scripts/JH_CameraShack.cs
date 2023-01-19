using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 위아래로 카메라 쉐이크
public class JH_CameraShack : MonoBehaviour
{
    // 카메라
    Transform cam;
    // 카메라 초기 위치
    Vector3 originPos;
    // 진폭
    public float amplitude = 0.2f;
    // 주기
    public float sinSpeed = 1000f;
    // 재생시간
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
        // 쉐이킹 전의 카메라 위치 저장
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
