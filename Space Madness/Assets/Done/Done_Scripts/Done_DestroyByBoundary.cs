using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.name.StartsWith("Done_Enemy Ship"))
            {               
                GameCore.CountForMultiplicator = 0;
                GameCore.Multiplicator = 1;
            }
            Destroy(other.gameObject);
        }
    }
}