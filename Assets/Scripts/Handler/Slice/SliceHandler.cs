using Slicer2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceHandler : Handler
{
    private Slicer2DController sliceController;

    public override void OnAwake()
    {

    }

    public override void OnStart()
    {
        sliceController = GetComponent<Slicer2DController>();
        sliceController.enabled = false;
    }
}
