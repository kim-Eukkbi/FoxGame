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

    public override void OnAwake()
    {
        EventManager<EventEnum, Chunk>.AddEvent(EventEnum.ChunkRemove, RemoveList);
        EventManager<EventEnum, string>.AddEvent(EventEnum.ChunkRespawn, Respawn);
       // chunkroot = Application.dataPath + "\\Resources\\PreFabs\\Chunk";

    }

    public override void OnStart()
    {
        List<Object> list = Resources.LoadAll("PreFabs/Chunk/").ToList();
        foreach (var item in list)
        {
            chunkAddrs.Add(item.name);
        }
       // chunkAddrs = Directory.GetFiles(chunkroot).ToList();
      /*  for (int i = 0; i < chunkAddrs.Count; i++)
        {
            chunkAddrs[i] = Path.GetFileName(chunkAddrs[i]).Split('.')[0];
        }*/
        FirstSpawn();
    }

    private void FirstSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            Chunk a = GameObjectPoolManager.Instance.GetGameObject("PreFabs/Chunk/" + chunkAddrs[Random.Range(0, chunkAddrs.Count)], transform).GetComponent<Chunk>();
            a.chunkType = ChunkType.Island;
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
        Chunk a = GameObjectPoolManager.Instance.GetGameObject("PreFabs/Chunk/" + chunkAddrs[Random.Range(0, chunkAddrs.Count)], transform).GetComponent<Chunk>();
        a.transform.position = chunks[chunks.Count -1].transform.position + chunkOffset;
        a.chunkType = ChunkType.Island;
        chunks.Add(a);
    }

}
