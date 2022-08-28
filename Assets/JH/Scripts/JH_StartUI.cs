using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// StartScene�� UI�� �����ϰ� �ʹ�.
// 1. �̹��� : alpha = 1 -> 0
// 2. StartUI, Charactor : Scale = 0 => 1.3 => 1 
public class JH_StartUI : MonoBehaviour
{
    [SerializeField]
    Image image;
    [SerializeField]
    RectTransform uiTransform;
    [SerializeField]
    Transform charTransforml;

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
            // ui�� charactor�� ũ�⸦ Ű��� �ʹ�.
            if (!isRevere)
            {
                uiTransform.localScale = Vector3.Lerp(uiTransform.localScale, targetScale, Time.deltaTime * 3f);
                charTransforml.localScale = Vector3.Lerp(charTransforml.localScale, targetScale, Time.deltaTime * 3f);

                if (uiTransform.localScale.x > targetScale.x - 0.02f)
                {
                    isRevere = true;
                    uiTransform.localScale = targetScale;
                    charTransforml.localScale = targetScale;
                }
            }
            else
            {
                uiTransform.localScale = Vector3.Lerp(uiTransform.localScale, Vector3.one, Time.deltaTime * 2f);
                charTransforml.localScale = Vector3.Lerp(charTransforml.localScale, Vector3.one, Time.deltaTime * 2f);

                if (uiTransform.localScale.x < Vector3.one.x + 0.01f)
                {
                    uiTransform.localScale = Vector3.one;
                    charTransforml.localScale = Vector3.one;
                }
            }
        }
    }
}
