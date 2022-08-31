using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chunk : MonoBehaviour  , IPoolableComponent
{
    [SerializeField]
    private ChunkType chunkType;

    public bool isSliceable = false;
    private Vector2 disablePoint = new Vector2(-20f, 0);
    internal Tween moveTween;

    public void Despawned()
    {

    }

    public void SetDisable()
    {
        if(isSliceable)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObjectPoolManager.Instance.UnusedGameObject(gameObject);

        }
    }

    public void Spawned()
    {
        EventManager<EventEnum, string>.AddEvent(EventEnum.SlowDown, SlowDown);
        EventManager<EventEnum, ChunkType>.Invoke(EventEnum.ChunkTypeSend, chunkType);

        moveTween = transform.DOMove(disablePoint, 10f).SetEase(Ease.Linear).SetSpeedBased().OnComplete(() =>
        {
            SetDisable();
            EventManager<EventEnum, Chunk>.Invoke(EventEnum.ChunkRemove, this);
            EventManager<EventEnum, string>.Invoke(EventEnum.ChunkRespawn, "");
            
        });
    }

    public void SlowDown(string a)
    {
        moveTween.DOTimeScale(0, .5f).SetEase(Ease.Linear).OnComplete(() => moveTween.Kill());
    }

}

public enum ChunkType
{
    Island,
    Lab,
    Lake
}
