using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 링을 먹으면 점수를 증가시키고 싶다.
// 점수를 UI에 표시하고 싶다.
public class JH_Score : MonoBehaviour
{
    public Text textRing;
    int ring = 0;
    int _topRing = 0;
    public int RING
    {
        get
        {
            return ring;
        }
        set
        {
            ring = value;
            textRing.text = ring.ToString("D4");
            if (ring > _topRing)
            {
                _topRing = ring;
                PlayerPrefs.SetInt("TopRing", _topRing);
            }
        }
    }

    public static JH_Score Instance;

    void Awake()
    {
            Instance = this;
    }
    private void Start()
    {
        textRing = GameObject.Find("Text_Ring").GetComponent<Text>();
        _topRing = PlayerPrefs.GetInt("TopRing", 0);
        ring = 0;
    }

    private void Update()
    {

    }
}
