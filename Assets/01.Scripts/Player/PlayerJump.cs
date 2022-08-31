using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerJump : MonoBehaviour
{

    public bool isJumped = false;
    public bool isGround = false;
    private Rigidbody2D rigd;

    public void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        EventManager<EventEnum, KeyCode>.AddEvent(EventEnum.PlayerInput, Jump);
    }

/*    public void FixedUpdate()
    {
        if (isJumped && !isGround)
        {
            print("???");
           
        }
    }*/

    private void Jump(KeyCode keyCode)
    {
        if (!isJumped && isGround && keyCode == KeyCode.Space)
            Jump();
    }

    private void Jump()
    {
        isJumped = true;
        rigd.velocity = Vector2.zero;
        rigd.AddForce(Vector2.up * 6,ForceMode2D.Impulse);
        /*transform.DOMoveY(-.5f, .35f).OnComplete(()=>
        {
            transform.DOMoveY(-2.24f, .35f).SetEase(Ease.Linear).OnComplete(() =>
            {
                
            });
        });*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
            isJumped = false;
        }
    }
}
