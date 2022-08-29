using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class JH_Director1 : MonoBehaviour
{
    PlayableDirector pd;
    public GameObject sonic;
    public GameObject tails;
    public GameObject knuckles;

    public GameObject cine_player;
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();

        sonic.SetActive(false);
        tails.SetActive(false);
        knuckles.SetActive(false);

        character = GameObject.FindGameObjectWithTag("Player");
        character.transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� ���� �ð��� ��ü �ð��� ũ�ų� ������(����ð��� �� �Ǹ�)
        if (pd.time >= pd.duration)
        {
            cine_player.SetActive(false);
            character.transform.position = Vector3.zero;
            Destroy(gameObject);
        }
        else
        {

            switch (NK_CharacterData.instance.currentCharacter)
            {
                case Character.Sonic:
                    sonic.SetActive(true);
                    break;
                case Character.Tails:
                    tails.SetActive(true);
                    break;
                case Character.Knuckles:
                    knuckles.SetActive(true);
                    break;
            }
        }

    }
}
