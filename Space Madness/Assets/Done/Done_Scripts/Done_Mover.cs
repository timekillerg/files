using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_Mover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
            rigidbody.velocity = transform.forward * speed * GameCore.GameParameters.Acceleration * (AppCore.IsFastMotion ? 1.5f : 1f) * (AppCore.IsSlowMotion ? 1.5f : 1f);
        else if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
            rigidbody.velocity = transform.forward * speed * (AppCore.IsFastMotion ? 1.5f : 1f) * (AppCore.IsSlowMotion ? 0.67f : 1f);
        else if (gameObject.tag == "Bonus")
            rigidbody.velocity = transform.forward * speed * (AppCore.IsFastMotion ? 1.5f : 1f) * (AppCore.IsSlowMotion ? 0.67f : 1f);
    }
}
