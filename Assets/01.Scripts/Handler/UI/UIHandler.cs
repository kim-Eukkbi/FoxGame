using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class UIHandler : Handler
{
    [SerializeField, Header("타이틀")]
    private CanvasGroup title;
    [SerializeField]
    private Button settingBtn;
    [SerializeField]
    private Button playBtn;

    [SerializeField, Header("인게임")]
    private CanvasGroup ingame;
    [SerializeField]
    private Button pausebtn;
    [SerializeField]
    private Text ingameScore;
    [SerializeField]
    private List<Image> hartimgs;
    [SerializeField]
    private List<Sprite> harts;




    [SerializeField, Header("설정창")]
    private CanvasGroup setting;
    [SerializeField]
    private Slider mainVol;
    [SerializeField]
    private Slider sfxVol;
    [SerializeField]
    private Button mainbtn;
    [SerializeField]
    private Button sfxbtn;
    [SerializeField]
    private Button tutobtn;
    [SerializeField]
    private Button backbtn1;
    [SerializeField]
    private Button backbtn2;
    [SerializeField]
    private List<Sprite> volimgs;

    [SerializeField, Header("게임오버")]
    private CanvasGroup gameover;
    [SerializeField]
    private Button retrybtn;
    [SerializeField]
    private Button toTitlebtn;
    [SerializeField]
    private Light2D highLight;
    [SerializeField]
    private Text score;

    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        playBtn.onClick.AddListener(PressStartBtn);
        settingBtn.onClick.AddListener(OpenSetting);
        SettingInit();
        GameOverInit(); ;
    }

    private void IngameUiInit()
    {
        ingame.DOFade(1, 1f);

        pausebtn.onClick.AddListener(() =>
        {
            OpenSetting();
        });



        StartCoroutine(UpdateScore());

        IEnumerator UpdateScore()
        {
            while (true)
            {
                yield return null;
                ingameScore.text = "Score: " + ((int)GameManager.Instance.score).ToString();
            }
        }
    }

    private void SetHarts(int hp)
    {
        hartimgs[hp - 1].sprite = harts[1];
    }

    private void ResetHarts()
    {
        for (int i = 0; i < 3; i++)
        {
            hartimgs[i].sprite = harts[0];
        }
    }

    private void PressStartBtn()
    {
        title.DOFade(0, 1f).OnComplete(() => title.gameObject.SetActive(false));
        EventManager<EventEnum, string>.Invoke(EventEnum.GameStart, "");
        IngameUiInit();
    }


    private void SettingInit()
    {
        backbtn1.onClick.AddListener(OffSetting);
        backbtn2.onClick.AddListener(OffSetting);
        mainbtn.onClick.AddListener(() => Mute(mainbtn));
        sfxbtn.onClick.AddListener(() => Mute(sfxbtn));
    }

    private void GameOverInit()
    {
        EventManager<EventEnum, string>.AddEvent(EventEnum.GameOver, GameOverAnim);
        retrybtn.onClick.AddListener(Restart);
        toTitlebtn.onClick.AddListener(Restart);
    }

    private void GameOverAnim(string a)
    {
        GameManager.Instance.StopScore();

        Sequence sequence = DOTween.Sequence();

        retrybtn.interactable = false;
        toTitlebtn.interactable = false;

        highLight.intensity = 0;
        highLight.pointLightOuterAngle = 180;

        gameover.gameObject.SetActive(true);

        EventManager<EventEnum, string>.Invoke(EventEnum.SlowDown, "");

        sequence.Append(gameover.DOFade(1, 1f)).OnComplete(() =>
        sequence.Append(DOTween.To(() => highLight.intensity, x => highLight.intensity = x, 3, 1f)));
        sequence.Join(DOTween.To(() => highLight.pointLightOuterAngle, x => highLight.pointLightOuterAngle = x, 70, 2f)
            .OnComplete(() =>
            {
                retrybtn.interactable = true;
                toTitlebtn.interactable = true;
                score.DOText(((int)GameManager.Instance.score).ToString(), 1f, true, ScrambleMode.Numerals);
            }));
    }

    private void Restart()
    {
        GameManager.Instance.ReSetting();
    }

    private void Mute(Button mybtn)
    {
        if (mybtn.image.sprite == volimgs[0])
        {
            mybtn.image.sprite = volimgs[1];
        }
        else
        {
            mybtn.image.sprite = volimgs[0];
        }
    }

    private void OffSetting()
    {
        setting.DOFade(0, .5f).OnComplete(() => setting.gameObject.SetActive(false));
    }

    private void OpenSetting()
    {
        setting.gameObject.SetActive(true);
        setting.DOFade(1, .5f);
    }
}
