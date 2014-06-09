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
            Vector3 position = other.transform.position;
            position.y = position.y + 2;
            Transform child = Instantiate(bonusPiskUpEffect, position, Quaternion.identity) as Transform;
            Destroy(gameObject);
        }
    }
}
