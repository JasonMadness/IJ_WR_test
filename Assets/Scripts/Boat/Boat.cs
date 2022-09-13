using System.Net.NetworkInformation;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private FracturedBoat _fracturedBoat;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            FracturedBoat boat = Instantiate(_fracturedBoat, transform.position, transform.rotation);
            boat.Init(transform.localScale);
            boat.Explode(_explosionForce);
            Destroy(gameObject);            
        }
    }
}
