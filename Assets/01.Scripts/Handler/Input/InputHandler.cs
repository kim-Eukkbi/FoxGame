using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            if(!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetKeyDown(KeyCode.Space)|| Input.touchCount == 1)
                {
                    EventManager<EventEnum, KeyCode>.Invoke(EventEnum.PlayerInput, KeyCode.Space);
                }

                if (Input.GetKeyDown(KeyCode.Z) || Input.touchCount == 2)
                {
                    EventManager<EventEnum, KeyCode>.Invoke(EventEnum.PlayerInput, KeyCode.Z);
                    // GameManager.Instance.sliceHandler.SetSlice(true);
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    print("qweqwe");
                    EventManager<EventEnum, ChunkType>.Invoke(EventEnum.ChunkTypeSend, ChunkType.Island);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    EventManager<EventEnum, ChunkType>.Invoke(EventEnum.ChunkTypeSend, ChunkType.Lab);
                }


                if (Input.GetKeyDown(KeyCode.D))
                {
                    EventManager<EventEnum, ChunkType>.Invoke(EventEnum.ChunkTypeSend, ChunkType.Lake);
                }

                    /* if (Input.GetMouseButtonUp(0))
                     {
                         yield return null;
                         GameManager.Instance.sliceHandler.SetSlice(false);
                     }*/
                }
        }
    }
}
