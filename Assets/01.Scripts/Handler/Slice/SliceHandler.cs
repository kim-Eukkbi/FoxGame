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
        StartCoroutine(Set(isOn));

        IEnumerator Set(bool isOn)
        {
            if (isOn)
            {
                yield return new WaitForSeconds(.1f);
                sliceController.enabled = true;
            }
            else
            {
                yield return new WaitForSeconds(.1f);
                sliceController.enabled = false;
            }
        }

      
    }
}
