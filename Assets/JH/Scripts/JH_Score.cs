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
    }

    private void Update()
    {

    }
}
