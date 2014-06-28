using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_Mover_Bullets : MonoBehaviour
{
    public float speed;

    void Start()
    {
        rigidbody.velocity = transform.forward * speed * (AppCore.IsFastMotion && gameObject.tag != "Enemy" ? 2f : 1f);
    }
}
