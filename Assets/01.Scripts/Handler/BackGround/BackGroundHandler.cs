using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGroundHandler : Handler
{
    [SerializeField]
    private List<MeshRenderer> bg;
    [SerializeField]
    private List<Sprite> bgImgs;
    private float timeScale =1;


    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        //EventManager<EventEnum, ChunkType>.AddEvent(EventEnum.ChunkTypeSend, ChangeBackGround);
        EventManager<EventEnum, string>.AddEvent(EventEnum.SlowDown, SlowDown);
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
            xOffset += new Vector2(Time.deltaTime * speed * timeScale, 0);
            mr.material.SetTextureOffset("_MainTex", xOffset);
        }
    }

    private void SlowDown(string a)
    {
        DOTween.To(() => timeScale, x => timeScale = x, 0, .5f).SetEase(Ease.Linear);
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
