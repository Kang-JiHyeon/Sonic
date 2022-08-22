using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_ScriptManager : MonoBehaviour
{
    CharacterController controller;

    public static NK_ScriptManager scriptManager;

    private void Awake()
    {
        scriptManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
