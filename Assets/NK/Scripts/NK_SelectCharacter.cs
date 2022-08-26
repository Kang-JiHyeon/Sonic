using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NK_SelectCharacter : MonoBehaviour
{
    // 캐릭터를 선택하고 싶다.
    public Character character;
    public NK_SelectCharacter[] characters;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        NK_CharacterData.instance.currentCharacter = character;
        OnSelect();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != this)
                characters[i].OnDeSelect();
        }
    }

    void OnDeSelect()
    {
        anim.SetBool("IsSelect", false);
    }

    void OnSelect()
    {
        anim.SetBool("IsSelect", true);
    }
}
