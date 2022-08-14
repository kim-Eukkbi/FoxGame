using Slicer2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceHandler : Handler
{
    private Slicer2DController sliceController;

    public override void OnAwake()
    {
        GameManager.Instance.sliceHandler = this;
    }

    public override void OnStart()
    {
        sliceController = GetComponent<Slicer2DController>();
        sliceController.enabled = false;
    }

    public void SetSlice(bool isOn = true)
    {
        if(isOn)
        {
            sliceController.enabled = true;
        }
        else
        {
            sliceController.enabled = false;
        }
    }
}
