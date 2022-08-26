using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ȿ���� ����� ���
public class JH_SoundManager : MonoBehaviour
{
    //// ����� Ŭ�� ����
    //public enum AudioState
    //{
    //    Idle,
    //    Aim,
    //    Booster,
    //    BalloonHit,
    //    EnemyHit1,
    //    EnemyHit2,
    //    Fly,
    //    Jump,
    //    Ring,
    //    Spin
    //}
    public List<AudioClip> AudioClipList = new List<AudioClip>();
    public AudioSource sound;
    //public AudioSource BoosterSource;
    //public AudioState state = AudioState.Idle;
    public bool isStart = false;

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>();

    public static JH_SoundManager Instance;

    private void Awake()
    {
        Instance = this;

        // Ű-�� ���·� ����
        foreach(AudioClip clip in AudioClipList)
        {
            audioClipsDic.Add(clip.name, clip);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //switch (state)
        //{
        //    case AudioState.Idle:
        //        //soundEffect.Stop();
        //        break;
        //    case AudioState.Aim:
        //        AimSource.Play();
        //        break;
        //    case AudioState.Booster:
        //        BoosterSource.Play();
        //        break;
        //}

        //// ȿ���� ��� ���� �ƴ� ��
        //if (!soundEffect.isPlaying)
        //{
        //    soundEffect.Play();
        //    //isStart = true;
        //    //soundEffect.PlayOneShot(audioList[(int)AudioState.Booster]);
        //    //state = AudioState.Idle;
        //}
        // ȿ���� ����
        //if (isStart)
        //{
        //    isStart = false;
        //    state = AudioState.Idle;
        //}
    }
    public void PlaySound(string name)
    {
        if (!audioClipsDic.ContainsKey(name))
        {
            print($"{name} ����");
            return;
        }
        sound.PlayOneShot(audioClipsDic[name]);
    }

}
