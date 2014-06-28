using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

class ShowAndHideBonusIcon : MonoBehaviour
{
    public Vector3 OnScreenPosition;
    public Vector3 HidePosition;
    private float speed = 4f;
    private bool isBonusShown;

    void Start()
    {
        transform.position = HidePosition;
    }

    void Update()
    {
        StartCoroutine(BonusLifeTime(10));
        if ((gameObject.tag == "SlowIcon" && AppCore.IsSlowMotion)
            || (gameObject.tag == "FastIcon" && AppCore.IsFastMotion)
            || (gameObject.tag == "GuardIcon" && AppCore.IsGodMod)
            || (gameObject.tag == "HazardIcon" && GameCore.CurrentWeaponType == WeaponType.Acid)
            || (gameObject.tag == "PlasmaIcon" && GameCore.CurrentWeaponType == WeaponType.Plasma)
            || (gameObject.tag == "LazerIcon" && GameCore.CurrentWeaponType == WeaponType.Laser)
            || (gameObject.tag == "RocketIcon" && GameCore.CurrentWeaponType == WeaponType.Rocket)
            )

            if (!isBonusShown)
                ShowBonus();
            else
                HideBonus();
        else
            HideBonus();
    }

    private void ShowBonus()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.transform.position = Vector3.Lerp(transform.position, OnScreenPosition, Time.fixedDeltaTime * speed);
        if (rigidbody.position.z >= (OnScreenPosition.z - 0.1f) && rigidbody.position.z <= (OnScreenPosition.z + 0.1f))
            rigidbody.velocity = Vector3.zero;
    }

    private void HideBonus()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.transform.position = Vector3.Lerp(transform.position, HidePosition, Time.fixedDeltaTime * speed);
        if (rigidbody.position.z >= (HidePosition.z - 0.2f) && rigidbody.position.z <= (HidePosition.z + 0.2f))
        {
            rigidbody.velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }

    IEnumerator BonusLifeTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isBonusShown = true;
    }
}
