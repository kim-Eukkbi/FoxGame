using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;
using System;

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
        var pice = slice.GetGameObjects();
        Rigidbody2D rigidbody = pice[0].GetComponent<Rigidbody2D>();
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.gravityScale = 1f;
    }
}
