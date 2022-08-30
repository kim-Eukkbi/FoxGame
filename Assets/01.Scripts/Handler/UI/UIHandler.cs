using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIHandler : Handler
{
    [SerializeField, Header("Å¸ÀÌÆ²")]
    private CanvasGroup title;
    [SerializeField]
    private Button settingBtn;
    [SerializeField]
    private Button PlayBtn;

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
}
