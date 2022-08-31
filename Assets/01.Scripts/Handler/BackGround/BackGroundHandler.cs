using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BackGroundHandler : Handler
{
    [SerializeField]
    private List<MeshRenderer> bg;
    [SerializeField]
    private List<Material> bgImgs;
    private float timeScale =1;
    private Coroutine backco;
    private ChunkType backType = ChunkType.Lab;


    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        EventManager<EventEnum, ChunkType>.AddEvent(EventEnum.ChunkTypeSend, ChangeBackGround);
        EventManager<EventEnum, string>.AddEvent(EventEnum.SlowDown, SlowDown);

        SetBackToLab();
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


    private void ChangeBackGround(ChunkType type)
    {
        if (backType.Equals(type))
            return;

        StopCoroutine(backco);
        switch (type)
        {
            case ChunkType.Island:
                SetBackToIsland();
                backType = ChunkType.Island;
                break;
            case ChunkType.Lab:
                SetBackToLab();
                backType = ChunkType.Lab;
                break;
            case ChunkType.Lake:
                SetBackToLake();
                backType = ChunkType.Lake;
                break;
        }
    }

    private void SetBackToLake()
    {
        for(int i =0; i < 5;i++)
        {
            bg[i].material = bgImgs[i + 6];
            backco = StartCoroutine(MoveingBackGround(bg[i], 0.5f - i / 10f));
        }

    }

    private void SetBackToLab()
    {
        bg[4].material = bgImgs[5];
        backco = StartCoroutine(MoveingBackGround(bg[4], 0.5f));
        for (int i = 0; i < 4; i++)
        {
            bg[i].material = bgImgs[0];
        }
    }

    private void SetBackToIsland()
    {
        for (int i = 0; i < 4; i++)
        {
            bg[i].material = bgImgs[i + 1];
            backco = StartCoroutine(MoveingBackGround(bg[i], 0.5f - i / 10f));
        }
        bg[4].material = bgImgs[0];
    }
}
