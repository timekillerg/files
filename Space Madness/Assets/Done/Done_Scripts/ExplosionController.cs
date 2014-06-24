using UnityEngine;

class ExplosionController : MonoBehaviour
{
    public GameObject explosionObject;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
            Instantiate(explosionObject, transform.position, transform.rotation);
    }
}
