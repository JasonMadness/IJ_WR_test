using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    private float maxValue = 0.5f;

    private void Start()
    {
        x = Random.Range(0, maxValue);
        y = Random.Range(0, maxValue);
        z = Random.Range(0, maxValue);
    }

    private void Update()
    {
        transform.Rotate(x, y, z);
    }
}
