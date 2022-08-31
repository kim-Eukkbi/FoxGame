using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDead : MonoBehaviour
{
    private void Start()
    {
        EventManager<EventEnum, string>.AddEvent(EventEnum.SlowDown,SlowDown);
    }

    private void SlowDown(string a)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Sequence sequence = DOTween.Sequence();
            
        sequence.Append(renderer.DOFade(0, 1f).OnComplete(()=>{
            GetComponentInParent<PlayerAnimation>().SetBool("isDead", true);
            transform.parent.position = new Vector3(0, -2.3f, 0);
            transform.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
        }));
        sequence.Append(renderer.DOFade(1, 1f));
    }
}
