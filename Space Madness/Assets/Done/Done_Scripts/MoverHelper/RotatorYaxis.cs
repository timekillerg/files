using UnityEngine;
using System.Collections;

public class RotatorYaxis : MonoBehaviour
{
    public float tumble;

    void Start()
    {
        Vector3 randomYrotator = Random.insideUnitSphere;
        randomYrotator.x = 0;
        randomYrotator.y = 0;
        rigidbody.angularVelocity = randomYrotator * tumble;
    }
}
