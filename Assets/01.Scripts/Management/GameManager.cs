using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �̱��� (�������� Awake �Լ� �ȿ� ����)
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
                    Debug.LogError("���ӸŴ����� �������� �ʽ��ϴ�!!");
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
        int setWidth = 1920; // ����� ���� �ʺ�
        int setHeight = 1080; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
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
