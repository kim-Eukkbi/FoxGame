using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chunk : MonoBehaviour  , IPoolableComponent
{
    public ChunkType chunkType;
    private Vector2 disablePoint = new Vector2(-20f, 0);
    internal Tween moveTween;

    public void Despawned()
    {

    }

    public void SetDisable()
    {
        GameObjectPoolManager.Instance.UnusedGameObject(gameObject);
    }

    public void Spawned()
    {
        moveTween = transform.DOMove(disablePoint, 10f).SetEase(Ease.Linear).SetSpeedBased().OnComplete(() =>
        {
            SetDisable();
            EventManager<EventEnum, Chunk>.Invoke(EventEnum.ChunkRemove, this);
            EventManager<EventEnum, string>.Invoke(EventEnum.ChunkRespawn, "");
        });
        StartCoroutine(ChangeBackGround());
    }

    public IEnumerator ChangeBackGround()
    {
        yield return new WaitForSeconds(5f);
        EventManager<EventEnum, ChunkType>.Invoke(EventEnum.ChunkTypeSend, chunkType);
    }

}

public enum ChunkType
{
    Island,
    Lab,
    City
}
