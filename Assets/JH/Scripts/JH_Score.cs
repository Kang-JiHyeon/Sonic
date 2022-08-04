using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ������ ������ ������Ű�� �ʹ�.
// ������ UI�� ǥ���ϰ� �ʹ�.
public class JH_Score : MonoBehaviour
{
    public Text textScore;
    int score = 0;

    public int SCORE
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            textScore.text = score.ToString("D4"); ;
        }
    }

    public static JH_Score Instance;
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        } 
    }
}
