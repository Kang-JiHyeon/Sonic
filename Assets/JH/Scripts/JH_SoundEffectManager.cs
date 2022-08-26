using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ȿ���� ����� ���
public class JH_SoundEffectManager : MonoBehaviour
{
    // ����� Ŭ�� ����]
    public enum AudioState
    {
        Idle,
        Aim,
        Booster,
        BalloonHit,
        EnemyHit1,
        EnemyHit2,
        Fly,
        Jump,
        Ring,
        Spin
    }
    public List<AudioClip> audioList = new List<AudioClip>();
    public AudioState state = AudioState.Idle;
    AudioSource soundEffect;
    public bool isStart = false;

    public static JH_SoundEffectManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AudioState.Aim:
                soundEffect.clip = audioList[(int)AudioState.Aim];
                break;
            case AudioState.Booster:
                soundEffect.clip = audioList[(int)AudioState.Booster];
                break;
            default:
                soundEffect.clip = audioList[(int)AudioState.Idle];
                break;
        }

        //// ȿ���� ��� ���� �ƴ� ��
        //if (!soundEffect.isPlaying)
        //{
        //    isStart = true;
        //}

        // ȿ���� ����
        if (state != AudioState.Idle)
        {
            soundEffect.Play();
            //isStart = false;
            state = AudioState.Idle;
        }
    }
}
