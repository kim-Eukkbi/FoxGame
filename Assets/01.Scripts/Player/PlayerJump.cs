using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerJump : MonoBehaviour
{

    private bool isJumped= false;
    private Rigidbody2D rigd;

    public void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        EventManager<EventEnum, KeyCode>.AddEvent(EventEnum.PlayerInput, Jump);
    }

    private void Jump(KeyCode keyCode)
    {
        if (!isJumped && keyCode == KeyCode.Space)
            Jump();
    }

    private void Jump()
    {
        isJumped = true;
        transform.DOMoveY(-.5f, .35f).OnComplete(()=>
        {
            transform.DOMoveY(-2.24f, .35f).SetEase(Ease.Linear).OnComplete(() =>
            {
                isJumped = false;
            });
        });
    }
}
