using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed;
    [SerializeField] private float _endSpeedCoefficient;
    [SerializeField] private float _horizontalBoundary;
    [SerializeField] private float _startOffset;
    [SerializeField] private int _endOffset;
    [SerializeField] private float _delayBeforeEnd;
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private GameObject _model;
    [SerializeField] private ParticleSystem _splash;
    [SerializeField] private ParticleSystem _trail;

    private float _distanceTraveled;
    private float _horizontalPosition;
    private bool _onFinish = false;

    public event UnityAction RoadEnded;

    private void Start()
    {
        _distanceTraveled += _startOffset;
    }

    private void Move()
    {
        _distanceTraveled += _speed * Time.deltaTime;
        Vector3 moveDirection = _pathCreator.path.GetPointAtDistance(_distanceTraveled);
        _horizontalPosition -= Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position = new Vector3(moveDirection.x, moveDirection.y, _horizontalPosition);
    }

    private void ClampHorizontalPosition()
    {
        _horizontalPosition = Mathf.Clamp(_horizontalPosition, -_horizontalBoundary, _horizontalBoundary);
    }

    private IEnumerator MoveToEnd()
    {
        yield return new WaitForSeconds(_delayBeforeEnd);
        float interpolateValue = 0;
        Vector3 position = transform.position;

        while (interpolateValue < 1)
        {
            transform.position = Vector3.Lerp(position, _endPosition, interpolateValue);
            interpolateValue += Time.deltaTime * _speed / _endSpeedCoefficient;
            yield return new WaitForEndOfFrame();
        }

        _model.SetActive(false);
        _splash.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_onFinish == false)
        {
            Move();
            ClampHorizontalPosition();
        }

        if (transform.position.x >= _pathCreator.path.GetPoint(_pathCreator.path.NumPoints - _endOffset).x && _onFinish == false)
        {
            _onFinish = true;
            _trail.gameObject.SetActive(false);
            RoadEnded?.Invoke();
            StartCoroutine(MoveToEnd());
        }
    }
}