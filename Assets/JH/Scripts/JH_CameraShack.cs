using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ʒ��� ī�޶� ����ũ
public class JH_CameraShack : JH_CameraShakeBase
{
    [SerializeField]
    CameraShakeInfo info;

    // ī�޶�
    Transform cam;

    // ����ð�
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
