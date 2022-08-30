using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCol : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SetSlow"))
        {
            GameManager.Instance.timeHandler.TimeScaleControll(.3f, .3f,Ease.InQuad);
        }
        else if(other.CompareTag("Obstacle"))
        {
            transform.GetComponent<PlayerHp>().SetHp(1);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SetSlow"))
        {
            GameManager.Instance.timeHandler.TimeScaleControll(1f, .5f,Ease.INTERNAL_Zero);
        }
        else if (other.CompareTag("Obstacle"))
        {

        }
    }
}
