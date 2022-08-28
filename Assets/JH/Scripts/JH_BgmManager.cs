using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// ������ BGM�� �����ϰ� �ʹ�.
public class JH_BgmManager : MonoBehaviour
{
    AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        BGM = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "SelectScene")
        {
            BGM.volume = Mathf.Lerp(BGM.volume, 0.1f, Time.deltaTime);

            if (BGM.volume < 0.13f)
            {
                BGM.volume = 0.1f;
                return;
            }
        }
    }
}
