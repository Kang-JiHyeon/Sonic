using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing
;

// �ν��� ȿ���� ���۵Ǹ� post-process ȿ���� �ø��ٰ� 
// �ν��� ȿ���� ������ �ε巴�� post-processȿ���� ���̴ٰ� ���� �ʹ�.
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

        // �ν��� ���¶�� post-process�� Ȱ��ȭ�ϰ� ȿ���� �ø��ٰ�
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
        // �ƴ϶�� post-process ȿ���� ���̴ٰ�
        //else
        //{
        //    // ���� ���� �����ϸ� ��Ȱ��ȭ�Ѵ�.
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
