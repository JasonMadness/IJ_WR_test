using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WaterDrawer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector3 _startPosition;

    [SerializeField] private Material _material;
    [SerializeField] private Vector3 _heigth;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPosition(Vector3 position)
    {
        _lineRenderer.positionCount = 2;
        _startPosition = position;
    }

    private void Draw()
    {
        if (_startPosition != Vector3.zero)
        {
            _lineRenderer.SetPosition(0, _startPosition + _heigth);
            _lineRenderer.SetPosition(1, transform.position + _heigth);
            _material.mainTextureScale = new Vector2(transform.position.x - _startPosition.x, 1);
        }
    }

    private void Update()
    {
        Draw();
    }
}
