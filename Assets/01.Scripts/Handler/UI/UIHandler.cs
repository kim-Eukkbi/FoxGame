using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIHandler : Handler
{
    [SerializeField, Header("타이틀")]
    private CanvasGroup title;
    [SerializeField]
    private Button settingBtn;
    [SerializeField]
    private Button PlayBtn;



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

    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        PlayBtn.onClick.AddListener(PressStartBtn);
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
        setting.alpha = 0;
        setting.gameObject.SetActive(false);
    }
}
