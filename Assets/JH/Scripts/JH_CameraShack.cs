using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 위아래로 카메라 쉐이크
public class JH_CameraShack : JH_CameraShakeBase
{
    [SerializeField]
    CameraShakeInfo info;

    // 카메라
    Transform cam;

    // 재생시간
    public float playTime = 0.1f;
    float theta = 0;

    public static JH_CameraShack Instance;

    private void Awake()
    {
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
        base.Init(cam.position);

        float currentTime = 0;

        while(currentTime < playTime)
        {
            currentTime += Time.deltaTime;
            Play(cam, info);
            yield return null;
        }
        Stop(cam);
    }

    public override void Play(Transform transform, CameraShakeInfo info)
    {
        theta += info.sinSpeed * Time.deltaTime;
        transform.position = originPos + Vector3.up * Mathf.Sin(theta) * info.amplitude;
    }

    public override void Stop(Transform transform)
    {
        transform.position = originPos;
        theta = 0f;
    }
}
