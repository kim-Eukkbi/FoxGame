using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : Handler
{
    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        StartCoroutine(InputStart());
    }

    private IEnumerator InputStart()
    {
        while(true)
        {
            yield return null;
            if (Input.GetKey(KeyCode.Space))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    GameManager.Instance.sliceHandler.SetSlice(true);
                }

                
            }


            if (Input.GetMouseButtonUp(0))
            {
                yield return null;
                GameManager.Instance.sliceHandler.SetSlice(false);
            }
        }
    }
}
