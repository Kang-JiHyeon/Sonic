using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing
;

// 부스터 효과가 시작되면 post-process 효과를 늘리다가 
// 부스터 효과가 끝나면 부드럽게 post-process효과를 줄이다가 끄고 싶다.
public class JH_CameraPostProcess : MonoBehaviour
{
    PostProcessVolume _postProcess;
    DepthOfField _depthOfField;
    Vignette _vignette;

    public float maxFocalLenght = 20f;
    public float maxIntensity = 0.2f;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _postProcess = GetComponent<PostProcessVolume>();

        _postProcess.profile.TryGetSettings(out _depthOfField);
        _postProcess.profile.TryGetSettings(out _vignette);
        _postProcess.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (NK_Booster.Instance.isBooster)
        {
            _postProcess.enabled = true;

            _depthOfField.focalLength.value = Mathf.Lerp(_depthOfField.focalLength.value, maxFocalLenght, Time.deltaTime * speed);
            _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, maxIntensity, Time.deltaTime * speed);

            if (_depthOfField.focalLength.value > maxFocalLenght - 1f)
            {
                _depthOfField.focalLength.value = maxFocalLenght;
            }

            if (_vignette.intensity.value > maxIntensity - 0.01f)
            {
                _vignette.intensity.value = maxIntensity;
            }

        }
        else
        {
            _depthOfField.focalLength.value = Mathf.Lerp(_depthOfField.focalLength.value, 1f, Time.deltaTime);
            _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, 0f, Time.deltaTime);

            if(_depthOfField.focalLength.value < 1.1f && _vignette.intensity.value < 0.01f)
            {
                _depthOfField.focalLength.value = 1f;
                _vignette.intensity.value = 0f;
                _postProcess.enabled = false;
            }
        }

        // 부스터 상태라면 post-process를 활성화하고 효과를 늘리다가
        //    gameObject.SetActive(true);

        //    //_depthOfField.focalLength.value = Mathf.Lerp(_depthOfField.focalLength.value, maxFocalLenght, Time.deltaTime);
        //    //_vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, maxIntensity, Time.deltaTime );
        //    _depthOfField.focalLength.value = 20f;
        //    _vignette.intensity.value = 0.2f;

        //if (_depthOfField.focalLength.value > maxFocalLenght)
        //{
        //    _depthOfField.focalLength.value = maxFocalLenght;
        //}

        //if (_vignette.intensity.value > maxIntensity)
        //{
        //    _vignette.intensity.value = maxIntensity;
        //}

        //}
        // 아니라면 post-process 효과를 줄이다가
        //else
        //{
        //    // 설정 값에 도달하면 비활성화한다.
        //    _depthOfField.focalLength.value = Mathf.Lerp(maxFocalLenght, _depthOfField.focalLength.value, Time.deltaTime);
        //    _vignette.intensity.value = Mathf.Lerp(maxIntensity, _vignette.intensity.value, Time.deltaTime * 0.1f);


        //    if(_depthOfField.focalLength.value <= 1f && _vignette.intensity.value <= 0f)
        //    {
        //        _depthOfField.focalLength.value = 1f;
        //        _vignette.intensity.value = 0f;
        //        gameObject.SetActive(false);
        //    }
        //}
    }
}
