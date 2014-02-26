using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
		public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
		public float speed;
		public Boundary boundary;
		public float tilt;
		public GameObject shot;
		public Transform shotSpawn;
		public float fireRate;
		private float nextFire;

		void Update ()
		{
				if (Time.time > nextFire) {
						nextFire = Time.time + fireRate;
						Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
						audio.Play ();
				}
		}

		void FixedUpdate ()
		{
			Vector3 movement;
			movement = new Vector3 (0.0f, 0.0f, 0.0f);
			Debug.Log(Input.GetAxis("Horizontal"));
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;				
				if (Physics.Raycast (ray, out hit, 100)) {					
					if (hit.collider.tag == "LeftButton") {
						movement = new Vector3 (-1.0f, 0.0f, 0.0f);	

					}					
					if (hit.collider.tag == "RightButton") {
						movement = new Vector3 (1.0f, 0.0f, 0.0f);						
					}					
				}
			}
		while (!Input.GetMouseButtonUp(0)) {
			rigidbody.velocity = movement * speed;
			rigidbody.position = new Vector3 (
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
			rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		}

			
		}
}
