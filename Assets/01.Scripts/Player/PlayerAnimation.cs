using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    private bool isJumped = false;

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
            default:
                break;
        }
    }

    public void PlayJumpAnimation()
    {
        if(!isJumped)
        {
            StartCoroutine(JumpCo());
        }
        else
        {
            return;
        }
    }

    public IEnumerator JumpCo()
    {
        SetBool("isJump", true);
        isJumped = true;
        yield return new WaitForSeconds(.7f);
        SetBool("isJump", false);
        isJumped = false;
    }



    public void SetBool(string name,bool istrue)
    {
        playerAnimator.SetBool(name, istrue);
    }
}
