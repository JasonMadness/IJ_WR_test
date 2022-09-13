using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private Vector3 _scaleUpgrade;
    [SerializeField] private float _scaleUpdateSpeed;
    [SerializeField] private Vector3 _endScaleUpgrade;
    [SerializeField] private float _endUpgradeDelay;
    [SerializeField] private float _modelUpgradeDelay;
    [SerializeField] private float _endUpgradeCount;
    [SerializeField] private float _endUpgradeInterval;

    private Vector3 _targetScale;
    private bool _roadEnded = false;

    public event UnityAction<int> Scaled;

    private void Start()
    {
        _targetScale = transform.localScale;
    }

    public void IncreaseAllAxis()
    {
        _targetScale += _scaleUpgrade;
    }

    public void ChangeAtEnd()
    {
        _roadEnded = true;
        StartCoroutine(AnimateModel());
        StartCoroutine(Increase());
    }

    private IEnumerator Increase()
    {
        yield return new WaitForSeconds(_endUpgradeDelay);
        Vector3 scale = transform.localScale;
        WaitForSeconds delay = new WaitForSeconds(_endUpgradeInterval);

        for (int i = 0; i < _endUpgradeCount; i++)
        {
            scale += _endScaleUpgrade;
            transform.localScale = scale;
            Scaled?.Invoke(i + 1);
            yield return delay;
        }

        Scaled?.Invoke(0);
    }

    private IEnumerator AnimateModel()
    {
        yield return new WaitForSeconds(_modelUpgradeDelay);
        GetComponent<Animator>().SetTrigger("GoStraight");
    }

    private void Update()
    {
        if (_roadEnded == false)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, _scaleUpdateSpeed * Time.deltaTime);
        }
    }
}
