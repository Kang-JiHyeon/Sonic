using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NK_SelectCharacter : MonoBehaviour, IPointerClickHandler
{
    // 캐릭터를 선택하고 싶다.
    public Character character;
    public NK_SelectCharacter[] characters;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
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
        image.color = new Color(0.5f, 0.5f, 0.5f);
    }

    void OnSelect()
    {
        image.color = new Color(1f, 1f, 1f);
    }
}
