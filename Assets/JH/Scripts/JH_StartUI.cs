using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// StartScene의 UI를 관리하고 싶다.
// 1. 이미지 : alpha = 1 -> 0
// 2. StartUI, Charactor : Scale = 0 => 1.3 => 1 
public class JH_StartUI : MonoBehaviour
{
    [SerializeField]
    Image image;
    [SerializeField]
    RectTransform uiTransform;
    [SerializeField]
    Transform charTransforml;
    [SerializeField]
    float speed = 3f;
    
    Color color;
    Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);
    bool isRevere = false;

    // Start is called before the first frame update
    void Start()
    {
        color = Vector4.one;
        uiTransform.localScale = Vector3.zero;
        charTransforml.localScale = Vector3.zero;
    }
    bool isSelect = false;
    // Update is called once per frame
    void Update()
    {
        if (image)
        {
            color.a -= 0.005f;
            image.color = color;

            if (color.a < 0f)
            {
                isSelect = true;
                Destroy(image);
            }
        }

        if(isSelect)
        {
            // ui와 charactor의 크기를 키우고 싶다.
            if (!isRevere)
            {
                uiTransform.localScale = Vector3.Lerp(uiTransform.localScale, targetScale, Time.deltaTime * speed);
                charTransforml.localScale = Vector3.Lerp(charTransforml.localScale, targetScale, Time.deltaTime * speed);

                if (uiTransform.localScale.x > targetScale.x - 0.02f)
                {
                    isRevere = true;
                    uiTransform.localScale = targetScale;
                    charTransforml.localScale = targetScale;
                }
            }
            else
            {
                uiTransform.localScale = Vector3.Lerp(uiTransform.localScale, Vector3.one, Time.deltaTime * speed);
                charTransforml.localScale = Vector3.Lerp(charTransforml.localScale, Vector3.one, Time.deltaTime * speed);

                if (uiTransform.localScale.x < Vector3.one.x + 0.005f)
                {
                    uiTransform.localScale = Vector3.one;
                    charTransforml.localScale = Vector3.one;
                }
            }
        }
    }
}
