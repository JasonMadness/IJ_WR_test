using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMover : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Vector2 _offset;

    private void Start()
    {
        _material.mainTextureOffset = Vector2.zero;
    }

    private void FixedUpdate()
    {
        _material.mainTextureOffset += _offset;
    }
}
