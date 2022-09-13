using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedBoat : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;

    public void Init(Vector3 localScale)
    {
        transform.localScale = localScale;
    }

    public void Explode(float explosionForce)
    {
        Rigidbody[] pieces = GetComponentsInChildren<Rigidbody>(); 

        foreach (Rigidbody piece in pieces)
        {
            //piece.useGravity = true;
            piece.AddForce((Vector3.up / 2 + Random.insideUnitSphere) * explosionForce, ForceMode.Impulse);
        }

        Destroy(gameObject, _destroyDelay);
    }
}
