using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 효과음 재생을 담당
public class JH_SoundManager : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> audioClipList = new List<AudioClip>();
    //[SerializeField]
    //List<AudioSource> audioSourceList = new List<AudioSource>();

    public Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioSource> audioSourceDic = new Dictionary<string, AudioSource>();

    public static JH_SoundManager Instance;

    private void Awake()
    {
        Instance = this;

        AudioSource[] array = GetComponentsInChildren<AudioSource>();

        // 키-값 형태로 저장
        foreach(AudioClip clip in audioClipList)
        {
            audioClipDic.Add(clip.name, clip);
        }

        foreach (AudioSource source in array)
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

    }
    public void PlaySound(string name)
    {
        if (!audioSourceDic.ContainsKey(name))
        {
            print($"{name} 오디오 없음");
            return;
        }

        if(!audioSourceDic[name].isPlaying)
            audioSourceDic[name].PlayOneShot(audioClipDic[name]);
    }
}
