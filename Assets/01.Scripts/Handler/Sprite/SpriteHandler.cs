using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : Handler
{
    [SerializeField]
    private List<Spriteinfo> floorSprites;
    [SerializeField]
    private List<Spriteinfo> obstacleSprites;

    public override void OnAwake()
    {
        GameManager.Instance.spriteHandler = this;
    }

    public override void OnStart()
    {

    }

    public void SetingFloorSprites(List<FloorType> info,ChunkType type)
    {
        for (int i = 0; i < info.Count; i++)
        {
            switch (type)
            {
                case ChunkType.Island :
                    JudgeSpriteIsland(info[i]);
                    break;
                case ChunkType.Lab:
                    JudgeSpriteLab(info[i]);
                    break;
                case ChunkType.Lake:
                    JudgeSpriteLake(info[i]);
                    break;
            }
        }
    }

    public void JudgeSpriteIsland(FloorType item)
    {
        switch (item.floortype)
        {
            case FloortypeEnum.Left:
                item.renderer.sprite = floorSprites[0].sprite;
                break;
            case FloortypeEnum.Right:
                item.renderer.sprite = floorSprites[1].sprite;
                break;
            case FloortypeEnum.Normal:

                item.renderer.sprite = floorSprites[2].sprite;
                break;
            case FloortypeEnum.AirObstacle:
                item.renderer.sprite = obstacleSprites[Random.Range(0,2)].sprite;
                break;
            case FloortypeEnum.GroundObstacle:
                item.renderer.sprite = obstacleSprites[Random.Range(2, 4)].sprite;
                break;
        }

    }

    public void JudgeSpriteLab(FloorType item)
    {
        switch (item.floortype)
        {
            case FloortypeEnum.Left:
                item.renderer.sprite = floorSprites[3].sprite;
                break;
            case FloortypeEnum.Right:
                item.renderer.sprite = floorSprites[4].sprite;
                break;
            case FloortypeEnum.Normal:

                item.renderer.sprite = floorSprites[5].sprite;
                break;
            case FloortypeEnum.AirObstacle:
                item.renderer.sprite = obstacleSprites[Random.Range(4, 6)].sprite;
                break;
            case FloortypeEnum.GroundObstacle:
                item.renderer.sprite = obstacleSprites[Random.Range(6, 8)].sprite;
                break;
        }
    }

    public void JudgeSpriteLake(FloorType item)
    {
        switch (item.floortype)
        {
            case FloortypeEnum.Left:
                item.renderer.sprite = floorSprites[6].sprite;
                break;
            case FloortypeEnum.Right:
                item.renderer.sprite = floorSprites[7].sprite;
                break;
            case FloortypeEnum.Normal:

                item.renderer.sprite = floorSprites[8].sprite;
                break;
            case FloortypeEnum.AirObstacle:
                item.renderer.sprite = obstacleSprites[Random.Range(8, 10)].sprite;
                break;
            case FloortypeEnum.GroundObstacle:
                item.renderer.sprite = obstacleSprites[Random.Range(10, 11)].sprite;
                break;
        }
    }
}

[System.Serializable]
public class Spriteinfo
{
    public Sprite sprite;
    public FloortypeEnum floortype;
}
