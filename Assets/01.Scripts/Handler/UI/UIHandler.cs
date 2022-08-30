using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIHandler : Handler
{
    [SerializeField, Header("타이틀")]
    private CanvasGroup title;
    [SerializeField]
    private Button settingBtn;
    [SerializeField]
    private Button playBtn;



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

    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        playBtn.onClick.AddListener(PressStartBtn);
        settingBtn.onClick.AddListener(OpenSetting);
        SettingInit();
        GameOverInit();
    }

    private void PressStartBtn()
    {
        title.DOFade(0, 1f).OnComplete(()=> title.gameObject.SetActive(false));
        EventManager<EventEnum, string>.Invoke(EventEnum.GameStart, "");
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
        retrybtn.onClick.AddListener(Restart);
        toTitlebtn.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        GameManager.Instance.ReSetting();
    }

    private void Mute(Button mybtn)
    {
        if(mybtn.image.sprite == volimgs[0])
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
