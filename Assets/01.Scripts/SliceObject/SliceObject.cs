using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;
using System;
using DG.Tweening;

public class SliceObject : MonoBehaviour
{
    private Sliceable2D sliceable2D;

    private void Start()
    {
        sliceable2D = GetComponent<Sliceable2D>();
        sliceable2D.AddResultEvent(Sliced);
    }

    private void Sliced(Slice2D slice)
    {
        GameManager.Instance.timeHandler.TimeScaleControll(1f, .5f, Ease.INTERNAL_Zero);
        GameManager.Instance.sliceHandler.SetSlice(false);

        var pice = slice.GetGameObjects();
        Rigidbody2D rigidbody = pice[0].GetComponent<Rigidbody2D>();
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.gravityScale = 3f;

    }
}
