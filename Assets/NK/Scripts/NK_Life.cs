using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Life : MonoBehaviour
{
    public static NK_Life LifeManager;
    public GameObject lifeFactory;

    List<GameObject> lifes = new List<GameObject>();
    int life = 3;
    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
            if (life <= 0)
            {
                // 게임 오버
                GameManager.gameManager.m_state = GameManager.GameState.GameOver;
                PlayerPrefs.SetInt("Life", 3);
                PlayerPrefs.SetInt("Score", 0);
            }
        }
    }
    private void Awake()
    {
        LifeManager = this;
        if (PlayerPrefs.GetInt("Life") != 0)
        {
            Life = PlayerPrefs.GetInt("Life");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Life = 3;
        for (int i = 0; i < Life; i++)
        {
            AddLife(-926, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        print("life:"+Life);
        //print(lifes.Count);
        // 플레이어가 죽었을 때
        if (lifes.Count > 0 && Life < lifes.Count)
        {
            RemoveLife();

            //GameObject.Find("Player").GetComponent<Life>().enabled = false;
            //GameManager.Instance.failPanel.SetActive(true);
            PlayerPrefs.SetInt("Life", lifes.Count);
        }
    }
    private void AddLife(float startPos, int i)
    {
        GameObject addLife = Instantiate(lifeFactory);
        addLife.transform.parent = transform;
        addLife.GetComponent<RectTransform>().anchoredPosition = new Vector3(startPos + 80 * i, 380, 0);
        addLife.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        lifes.Add(addLife);
    }

    private void RemoveLife()
    {
        if (transform.childCount - 1 >= 0)
        {
            GameObject removeLife = lifes[transform.childCount - 1];
            lifes.Remove(removeLife);
            Destroy(removeLife);
        }
    }
}
