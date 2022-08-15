using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chunk : MonoBehaviour  , IPoolableComponent
{

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
            EventManager<string, Chunk>.Invoke("Remove", this);
            EventManager<string, string>.Invoke("Respawn", "");
        });
    }

}
