using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float timescale =1f;

    private void Update()
    {
        Time.timeScale = timescale;
    }
}
