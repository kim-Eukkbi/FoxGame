using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour  , IPoolableComponent
{
    public void Despawned()
    {

    }

    public void SetDisable()
    {
        GameObjectPoolManager.Instance.UnusedGameObject(gameObject);
    }

    public void Spawned()
    {

    }
}
