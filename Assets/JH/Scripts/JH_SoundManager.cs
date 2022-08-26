using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 효과음 재생을 담당
public class JH_SoundManager : MonoBehaviour
{
    //// 오디오 클립 지정
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

        // 키-값 형태로 저장
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

        //// 효과음 출력 중이 아닐 때
        //if (!soundEffect.isPlaying)
        //{
        //    soundEffect.Play();
        //    //isStart = true;
        //    //soundEffect.PlayOneShot(audioList[(int)AudioState.Booster]);
        //    //state = AudioState.Idle;
        //}
        // 효과음 시작
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
            print($"{name} 없음");
            return;
        }
        sound.PlayOneShot(audioClipsDic[name]);
    }

}
