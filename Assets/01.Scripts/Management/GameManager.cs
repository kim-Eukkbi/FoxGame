using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 싱글톤 (실질적인 Awake 함수 안에 있음)
    #region SingleTon
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    Debug.LogError("게임매니저가 존재하지 않습니다!!");
                }
            }

            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        OnAwake();
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = default;
        }
    }
    #endregion


    internal SoundHandler soundHandler;
    internal SliceHandler sliceHandler;
    internal TimeHandler timeHandler;
    internal SpriteHandler spriteHandler;
    public float score = 0f;


    public void OnAwake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        score = 0;
        StopScore();
        EventManager<EventEnum, string>.AddEvent(EventEnum.GameStart, StartSetScore);
        DOTween.KillAll();
        StopAllCoroutines();
        Time.timeScale = 1f;
        Application.targetFrameRate = 120;
        Screen.SetResolution(1920, 1080, true);
        SetResolution();
    }

    public void StartSetScore(string a)
    {
        StartCoroutine(Score());
    }

    public void StopScore()
    {
        StopCoroutine(Score());
    }


    IEnumerator Score()
    {
        while (true)
        {
            yield return null;
            score += Time.deltaTime * 100;
        }
    }


    public void SetResolution()
    {
        int setWidth = 1920; // 사용자 설정 너비
        int setHeight = 1080; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }

    public void ReSetting()
    {
        EventManager<EventEnum, string>.RemoveAllEvents();
        EventManager<EventEnum, Chunk>.RemoveAllEvents();
        EventManager<EventEnum, KeyCode>.RemoveAllEvents();
        EventManager<EventEnum, ChunkType>.RemoveAllEvents();
        DOTween.KillAll();
        SceneManager.LoadScene("InGame",LoadSceneMode.Single);
        
    }
}

[System.Serializable]
public enum EventEnum
{
    ChunkRemove,
    ChunkRespawn,
    ChunkTypeSend,
    GameStart,
    GameOver,
    GameRestart,
    PlayerInput,
    SlowDown
}
