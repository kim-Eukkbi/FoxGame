using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    private bool isJumped = false;
    private bool isAttacked = false;

    public void Start()
    {
        EventManager<EventEnum, KeyCode>.AddEvent(EventEnum.PlayerInput, CheckingInput);
    }


    public void CheckingInput(KeyCode keyCode)
    {
        switch(keyCode)
        {
            case KeyCode.Space:
                PlayJumpAnimation();
                break;
            case KeyCode.Z:
                PlayAttacAnimation();
                break;
            default:

                break;
        }
    }

    public void PlayAttacAnimation()
    {
        if (isAttacked)
        {
            return;
        }
        else
        {
            StartCoroutine(AttackCo());
        }
    }

    public void PlayJumpAnimation()
    {
        if(isJumped)
        {
            return;
        }
        else
        {
            StartCoroutine(JumpCo());
        }
    }

    public IEnumerator JumpCo()
    {
        SetBool("isJump", true);
        isJumped = true;
        yield return new WaitForSeconds(1.2f);
        SetBool("isJump", false);
        isJumped = false;
    }

    public IEnumerator AttackCo()
    {
        SetBool("isAttack", true);
        isAttacked = true;
        yield return new WaitForSeconds(.5f);
        SetBool("isAttack", false);
        isAttacked = false;
    }



    public void SetBool(string name,bool istrue)
    {
        playerAnimator.SetBool(name, istrue);
    }
}
