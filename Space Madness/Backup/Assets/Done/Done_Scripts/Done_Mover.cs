using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
      if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
           rigidbody.velocity = transform.forward * speed * GameCore.GameParameters.Acceleration;
      else if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
          rigidbody.velocity = transform.forward * speed;
      else if(gameobject.tag == "Bonus")
			rigidbody.velocity = transform.forward * speed;
    }
}
