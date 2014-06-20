using UnityEngine;
using System.Collections;
using AssemblyCSharp;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

[System.Serializable]
public class Weapon
{
    public string Name;
    public GameObject bolt;   
    public Transform shotSpawn;
    public float boltSpeed;
    public float timeBetweenShots;
    public float lifeTime;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;	 
	private float nextFire;

    public Weapon[] Weapons;
    public Weapon CurrentWeapon;
    public float BonusPickUpTime;
    
    public void SetBonusWeapon(string weaponName)
    {
        foreach (Weapon w in Weapons)
            if (w.Name == weaponName)
            {
                CurrentWeapon = w;
                BonusPickUpTime = Time.time;
                break;
            }
    }

    public void InstantiateWeaponBolt()
    {
        if (CurrentWeapon != null && CurrentWeapon.timeBetweenShots > (Time.time - BonusPickUpTime) && ((Time.time - BonusPickUpTime) > CurrentWeapon.lifeTime))
        {
            nextFire = Time.time + CurrentWeapon.timeBetweenShots;
            Instantiate(CurrentWeapon.bolt, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
    }

    
    void Start()
    {
        nextFire = Time.time + 0.5f;
    }
	
	void Update ()
	{
        if (Time.time > nextFire && !GameCore.isShowStartCountDown) 
		{
            InstantiateWeaponBolt();
		}
	}

	void FixedUpdate()
	{
		LoadTouchEvents ();
		LoadMouseEvents ();
	}

	void LoadTouchEvents ()
	{
		if (Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {					
				if (hit.collider.tag == "LeftButton") {
					rigidbody.velocity = Vector3.left*speed;
				}					
				if (hit.collider.tag == "RightButton") {
					rigidbody.velocity = Vector3.right*speed;
				}
			}
		}
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
				
		if (Input.touchCount == 0) {
			rigidbody.velocity = Vector3.zero;
		}
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);

	}

	void LoadMouseEvents ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;				
			if (Physics.Raycast (ray, out hit, 100)) {					
				if (hit.collider.tag == "LeftButton") {				
					rigidbody.velocity = Vector3.left*speed;
				}					
				if (hit.collider.tag == "RightButton") {
					rigidbody.velocity = Vector3.right*speed;
				}
			}
		}
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);

		if (Input.GetMouseButtonUp (0)) {
			rigidbody.velocity = Vector3.zero;
		}
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
