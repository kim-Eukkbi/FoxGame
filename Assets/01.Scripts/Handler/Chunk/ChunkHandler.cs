using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System.Linq;
using System.IO;

public class ChunkHandler : Handler
{
    private Vector3 chunkOffset = new Vector3(17.5f, 0);
    private List<Chunk> chunks = new List<Chunk>();
    private List<string> chunkAddrs = new List<string>();
    private bool istart = false;

    public override void OnAwake()
    {
        EventManager<EventEnum, Chunk>.AddEvent(EventEnum.ChunkRemove, RemoveList);
        EventManager<EventEnum, string>.AddEvent(EventEnum.GameStart, StartGame);
        EventManager<EventEnum, string>.AddEvent(EventEnum.ChunkRespawn, Respawn);
        chunks.Clear();
        chunkAddrs.Clear();
    }

    public override void OnStart()
    {
        List<Object> list = Resources.LoadAll("PreFabs/Chunk/").ToList();
        foreach (var item in list)
        {
            chunkAddrs.Add(item.name);
        }

        WaitForStart();
    }

    private void WaitForStart()
    {
        FirstSpawn();
    }

    private void StartGame(string justForevent)
    {
        istart = true;
    }


    private void FirstSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            Chunk a = GameObjectPoolManager.Instance.GetGameObject("PreFabs/Chunk/" + chunkAddrs[0], transform).GetComponent<Chunk>();
            a.SendType();
            a.SendFloorinfo();
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
        int i = 0;
        if(!istart)
        {
            i = 0;
        }
        else
        {
            i = Random.Range(0, chunkAddrs.Count);
        }

        Chunk a = GameObjectPoolManager.Instance.GetGameObject("PreFabs/Chunk/" + chunkAddrs[i], transform).GetComponent<Chunk>();
        a.transform.position = chunks[chunks.Count -1].transform.position + chunkOffset;
        if (GameManager.Instance.score >= 13000)
        {
            EventManager<EventEnum, string>.Invoke(EventEnum.GameOver, "");
        }
        else if (GameManager.Instance.score >= 7000)
        {
            a.chunkType = ChunkType.Lake;
        }
        else if (GameManager.Instance.score >= 3000)
        {
            a.chunkType = ChunkType.Island;
        }
        else
        {
            a.chunkType = ChunkType.Lab;
        }

        a.SendType();
        a.SendFloorinfo();
        chunks.Add(a);
    }

}
