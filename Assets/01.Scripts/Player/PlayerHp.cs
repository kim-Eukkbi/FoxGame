using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private int Hp = 3;

    public void SetDamage(int damege)
    {
        Hp -= damege;
        if (Hp <=0)
        {
            Dead();
            return;
        }
        GameManager.Instance.uiHandler.SetHarts(Hp);
    }

    public void Dead()
    {
        EventManager<EventEnum, string>.Invoke(EventEnum.GameOver, "");
    }
}
