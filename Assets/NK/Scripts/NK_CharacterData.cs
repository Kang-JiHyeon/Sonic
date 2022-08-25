using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Sonic,
    Tails,
    Knuckles
}
public class NK_CharacterData : MonoBehaviour
{
    public static NK_CharacterData instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter;
}
