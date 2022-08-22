using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeHandler : Handler
{
    public override void OnAwake()
    {
        GameManager.Instance.timeHandler = this;
    }

    public override void OnStart()
    {
    }


    public void TimeScaleControll(float targetTime,float transitionTime,Ease ease)
    {
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, targetTime, transitionTime).SetEase(ease);
    }
}
