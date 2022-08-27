using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 효과음 재생을 담당
public class JH_SoundManager : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> audioClipList = new List<AudioClip>();
    [SerializeField]
    List<AudioSource> audioSourceList = new List<AudioSource>();

    public Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioSource> audioSourceDic = new Dictionary<string, AudioSource>();

    public static JH_SoundManager Instance;

    private void Awake()
    {
        Instance = this;

        // 키-값 형태로 저장
        foreach(AudioClip clip in audioClipList)
        {
            audioClipDic.Add(clip.name, clip);
        }

        foreach (AudioSource source in audioSourceList)
        {
            audioSourceDic.Add(source.name, source);
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
        if (!audioSourceDic.ContainsKey(name))
        {
            print($"{name} 오디오 없음");
            return;
        }

        audioSourceDic[name].PlayOneShot(audioClipDic[name]);
    }
}
