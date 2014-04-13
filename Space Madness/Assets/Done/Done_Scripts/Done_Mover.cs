using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
      if (AppCore.GetCurrentStatus() == AppCore.Status.ANY_LEVEL)
           rigidbody.velocity = transform.forward * speed * GameCore.GameParameters.Acceleration;
      if (AppCore.GetCurrentStatus() == AppCore.Status.FAST_GAME)
          rigidbody.velocity = transform.forward * speed;
    }
}
