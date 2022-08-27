using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundHandler : Handler
{
    [SerializeField]
    private SpriteRenderer bg;
    [SerializeField]
    private List<Sprite> bgImgs;

    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        EventManager<EventEnum, ChunkType>.AddEvent(EventEnum.ChunkTypeSend, ChangeBackGround);
        StartCoroutine(MoveingBackGround());
    }

    private IEnumerator MoveingBackGround()
    {
        while(true)
        {
            yield return null;
            bg.material.mainTextureOffset += new Vector2(Time.deltaTime * .5f, 0);
        }
    }

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
    }
}
