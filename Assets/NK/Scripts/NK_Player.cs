using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Player : MonoBehaviour
{
    #region 상태정의
    enum State
    {
        Idle,
        Move,
        Attack
    };

    State m_state = State.Idle;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
            case State.Attack:
                Attack();
                break;
        }
    }

    private void Idle()
    {
        throw new NotImplementedException();
    }

    private void Move()
    {
        throw new NotImplementedException();
    }

    private void Attack()
    {
        throw new NotImplementedException();
    }
}
