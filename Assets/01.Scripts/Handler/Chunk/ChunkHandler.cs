using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChunkHandler : Handler
{
    private Vector2 spawnPoint = new Vector2(35.5f, 0);
    private Vector2 disablePoint = new Vector2(-20f, 0);

    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        GameObject a = GameObjectPoolManager.Instance.GetGameObject("PreFabs/Chunk/Chunk", transform);
        a.transform.position = spawnPoint;
        a.transform.DOMove(disablePoint, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            a.GetComponent<Chunk>().SetDisable();
        });
    }

}
