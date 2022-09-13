using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject _endingPanel;
    [SerializeField] private float _delay;
    [SerializeField] private float _alphaStep;
    [SerializeField] private GameObject _smile;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private Color _targetColor;

    public void ShowEndingPanel()
    {
        StartCoroutine(Reveal());
    }

    private IEnumerator Reveal()
    {
        Color color = _endingPanel.GetComponent<Image>().color;
        yield return new WaitForSeconds(_delay);

        while (color.a < _targetColor.a)
        {
            color.a += _alphaStep;
            _endingPanel.GetComponent<Image>().color = color;
            yield return new WaitForEndOfFrame();
        }

        _smile.SetActive(true);
        _nextButton.SetActive(true);
    }
}
