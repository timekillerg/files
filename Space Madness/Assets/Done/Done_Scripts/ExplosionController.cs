using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public GameObject explosionObject;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyShip"))
            Instantiate(explosionObject, transform.position, transform.rotation);
    }
}
