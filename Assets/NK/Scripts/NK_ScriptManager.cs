using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_ScriptManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal)
        {
            gameObject.GetComponent<PlayerHorizontalMove>().ena
        }
        else
        {
            GetComponent<NK_PlayerMove>().enabled = true;
        }
}
