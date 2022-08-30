using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderqueueFix : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    public void Start()
    {
        meshRenderer.material.renderQueue = 2000;
    }
}
