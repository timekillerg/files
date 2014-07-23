using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;


public class EnemyMover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
            rigidbody.velocity = transform.forward * speed * GameCore.GameParameters.Acceleration * (AppCore.IsFastMotion ? 1.5f : 1f) * (AppCore.IsSlowMotion ? 1.5f : 1f) * GameCore.Accelerate;
        else if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
            rigidbody.velocity = transform.forward * speed * (AppCore.IsFastMotion ? 1.5f : 1f) * (AppCore.IsSlowMotion ? 0.5f : 1f) * GameCore.Accelerate;
    }
}
