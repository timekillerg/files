//this laser controller script checks if the laser hits something, adds collision, deals with damage, impact effect, etc.
//it is needed once per laser effect in the demo scene
// it does not actually draw a laser beam

var boxCollider:BoxCollider;
var damage:float=3;

var impactEffect:GameObject;
var muzzleEffect:GameObject;


var _hit: RaycastHit;
var _hitTime: float;



function Start()
{	
if (muzzleEffect) Instantiate(muzzleEffect, transform.position, transform.rotation);

var direction = transform.TransformDirection(Vector3.forward);
var hit : RaycastHit;
 
	if (Physics.Raycast (transform.position, direction, hit)) 
	{ // if it hits something, this happens
	boxCollider.size.y=hit.distance;  //I set up a box collider to be along the laser...
	boxCollider.center.y+=hit.distance/2;
	if (impactEffect && (
    hit.collider.CompareTag("EnemyShip") ||
    hit.collider.CompareTag("EnemyBolt") ||
    hit.collider.CompareTag("Meteor")
    )) {
            Instantiate(impactEffect, hit.point, hit.transform.rotation);
            _hit = hit; 
            _hitTime = Time.time+0.03;
        }
	}
}

function Update() 
{
    if (_hitTime>0 && _hitTime<Time.time)
    {
        if( _hit.collider.CompareTag("EnemyShip") ||
            _hit.collider.CompareTag("EnemyBolt") ||
            _hit.collider.CompareTag("Meteor") ) 
        {
            _hit.transform.gameObject.SendMessage("OnTriggerEnter", this.collider); 
        }
    }
}
  