using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Tails : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.root.gameObject;
        anim = GetComponent<Animator>();
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("TailsJump");
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("BunkJump"))
        {
            controller.Move(Vector3.up * 0.3f);
            NK_PlayerMove.Instance.gravity = 1;
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Landing"))
        {
            NK_PlayerMove.Instance.gravity = 10;
        }
    }
}
