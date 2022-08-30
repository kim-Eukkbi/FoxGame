using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private int Hp = 3;

    public void SetHp(int damege)
    {
        Hp -= damege;
        if(Hp <=0)
        {
            Dead();
        }
    }

    public void Dead()
    {

    }
}
