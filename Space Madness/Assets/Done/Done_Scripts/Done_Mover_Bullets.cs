using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_Mover_Bullets : MonoBehaviour
{
    public float speed;

    void Start()
    {
        rigidbody.velocity = transform.forward * speed * (AppCore.IsFastMotion && !gameObject.CompareTag("EnemyBolt") ? 2f : 1f)*GameCore.Accelerate;
    }
}
