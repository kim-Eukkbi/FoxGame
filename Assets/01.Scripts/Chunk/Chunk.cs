using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chunk : MonoBehaviour  , IPoolableComponent
{
    public ChunkType chunkType;

    public bool isSliceable = false;
    private Vector2 disablePoint = new Vector2(-20f, 0);
    internal Tween moveTween;

    public List<FloorType> info = new List<FloorType>();

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

        moveTween = transform.DOMove(disablePoint, 10f).SetEase(Ease.Linear).SetSpeedBased().OnComplete(() =>
        { 
            SetDisable();
            EventManager<EventEnum, Chunk>.Invoke(EventEnum.ChunkRemove, this);
            EventManager<EventEnum, string>.Invoke(EventEnum.ChunkRespawn, "");
            
        });
    }

    public void SendFloorinfo()
    {
        GameManager.Instance.spriteHandler.SetingFloorSprites(info,chunkType);
    }

    public void SendType()
    {
        EventManager<EventEnum, ChunkType>.Invoke(EventEnum.ChunkTypeSend, chunkType);
    }

    public void SlowDown(string a)
    {
        moveTween.DOTimeScale(0, .5f).SetEase(Ease.Linear).OnComplete(() => moveTween.Kill());
    }

}


[System.Serializable]
public class FloorType
{
    public SpriteRenderer renderer;
    public FloortypeEnum floortype;
}

public enum FloortypeEnum
{
    Left,
    Right,
    Normal,
    AirObstacle,
    GroundObstacle
}

public enum ChunkType
{
    Island,
    Lab,
    Lake
}
