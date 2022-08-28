using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundHandler : Handler
{
    [SerializeField]
    private List<MeshRenderer> bg;
    [SerializeField]
    private List<Sprite> bgImgs;


    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        //EventManager<EventEnum, ChunkType>.AddEvent(EventEnum.ChunkTypeSend, ChangeBackGround);
        // StartCoroutine(MoveingBackGround());
        for(int i =0; i < bg.Count;i++)
        {
            StartCoroutine(MoveingBackGround(bg[i],0.5f - i/10f));
        }
    }

    private IEnumerator MoveingBackGround(MeshRenderer mr,float speed)
    {
        Vector2 xOffset = Vector2.zero;
        while (true)
        {
            yield return null;
            xOffset += new Vector2(Time.deltaTime * speed, 0);
            mr.material.SetTextureOffset("_MainTex", xOffset);
        }
    }
/*
    private void ChangeBackGround(ChunkType type)
    {
        switch(type)
        {
            case ChunkType.Island:
                bg.sprite = bgImgs[0];
                break;
            case ChunkType.Lab:
                bg.sprite = bgImgs[1];
                break;
            case ChunkType.City:
                bg.sprite = bgImgs[2];
                break;
        }
    }*/
}
