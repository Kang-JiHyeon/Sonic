using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NK_CharacterUI : MonoBehaviour
{
    public Sprite[] sprites;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprites[(int)NK_CharacterData.instance.currentCharacter];
    }
}
