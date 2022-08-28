using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

// ���׸ӽ��� �����ϰ� �ʹ�.
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
        // ���� ���� ���� �ð��� ��ü �ð��� ũ�ų� ������(����ð��� �� �Ǹ�)
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
