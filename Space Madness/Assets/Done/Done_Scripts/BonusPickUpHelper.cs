using UnityEngine;
using System.Collections;

public class BonusPickUpHelper : MonoBehaviour
{
    public GameObject bonusPiskUpEffect;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && bonusPiskUpEffect != null)
        {
            Instantiate(bonusPiskUpEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }        
    }
}
