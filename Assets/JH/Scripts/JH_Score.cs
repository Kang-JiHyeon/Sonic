using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ������ ������ ������Ű�� �ʹ�.
// ������ UI�� ǥ���ϰ� �ʹ�.
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
