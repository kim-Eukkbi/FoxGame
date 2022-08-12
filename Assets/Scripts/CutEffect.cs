using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Slicer2D
{
    public class CutEffect : MonoBehaviour
    {
        private Sliceable2D sliceable2D;
        private List<Sliceable2D> sliceObjs = new List<Sliceable2D>();

        public void Start()
        {
            sliceable2D = GetComponent<Sliceable2D>();
            sliceable2D.AddResultEvent(CutEvent);
        }

        private void CutEvent(Slice2D slice)
        {
            Rigidbody2D rigidbody;
            Debug.Log(this.gameObject.name);
            sliceObjs = Sliceable2D.GetList();
            rigidbody = sliceObjs[sliceObjs.Count - 2].GetComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            rigidbody.gravityScale = 1;
        }
    }
}
