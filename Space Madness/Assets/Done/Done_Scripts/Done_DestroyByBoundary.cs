using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            if (other.CompareTag("EnemyShip"))
            {
                GameCore.CountForMultiplicator = 0;
                GameCore.Multiplicator = 1;
            }
            Destroy(other.gameObject);
        }
    }
}