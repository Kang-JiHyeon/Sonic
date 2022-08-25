using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NK_SelectCharacter : MonoBehaviour, IPointerClickHandler
{
    public Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        NK_CharacterData.instance.currentCharacter = character;
    }
}
