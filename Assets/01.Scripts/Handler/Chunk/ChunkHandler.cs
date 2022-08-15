using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ChunkHandler : Handler
{
    private Vector3 chunkOffset = new Vector3(17.5f, 0);
    private List<Chunk> chunks = new List<Chunk>();
    private const string CHUNK_ADDR = "PreFabs/Chunk/Chunk";

    public override void OnAwake()
    {
        EventManager<string, Chunk>.AddEvent("Remove", RemoveList);
        EventManager<string, string>.AddEvent("Respawn", Respawn);
    }

    public override void OnStart()
    {
        FirstSpawn();
    }

    private void FirstSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            Chunk a = GameObjectPoolManager.Instance.GetGameObject(CHUNK_ADDR, transform).GetComponent<Chunk>();
            chunks.Add(a);
        }
        chunks[0].transform.position = Vector2.zero;
        chunks[1].transform.position = chunkOffset;
        chunks[2].transform.position = chunkOffset + chunkOffset;

    }

    public void RemoveList(Chunk targetChunk)
    {
        chunks.Remove(targetChunk);
    }


    public void Respawn(string justForevent)
    {
        Chunk a = GameObjectPoolManager.Instance.GetGameObject("PreFabs/Chunk/Chunk", transform).GetComponent<Chunk>();
        a.transform.position = chunks[chunks.Count -1].transform.position + chunkOffset;
        chunks.Add(a);
    }

}
