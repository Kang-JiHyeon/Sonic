using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

// 씨네머신을 제어하고 싶다.
public class JH_CinemachineDirector : MonoBehaviour
{
    [System.NonSerialized]
    public PlayableDirector pd;
    public GameObject sonic;
    public GameObject tails;
    public GameObject knuckles;

    TimelinePreferences timeline;
    CinemachineVirtualCamera cine;
    [SerializeField]
    public Camera camera;

    public bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        camera.enabled = false;

        sonic.SetActive(false);
        tails.SetActive(false);
        knuckles.SetActive(false);

        //pd.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 진행 중인 시간이 전체 시간과 크거나 같으면(재생시간이 다 되면)
        if(pd.time >= pd.duration)
        {
            GameManager.gameManager.m_state = GameManager.GameState.GameOver;
        }

        if (!isPlay) return;

        switch (NK_CharacterData.instance.currentCharacter)
        {
            case Character.Sonic:
                sonic.SetActive(true);
                break;
            case Character.Tails:
                tails.SetActive(true);
                break;
            case Character.Knuckles:
                knuckles.SetActive(true);
                break;
        }
    }
}
