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

    private static Transform objectTrananform;

    void Start()
    {
        objectTrananform = transform;
        objectTrananform.position = HidePosition;
    }

    void Update()
    {
        StartCoroutine(BonusLifeTime(10));
        if ((gameObject.CompareTag("SlowIcon") && AppCore.IsSlowMotion)
            || (gameObject.CompareTag("FastIcon") && AppCore.IsFastMotion)
            || (gameObject.CompareTag("GuardIcon") && AppCore.IsGodMod)
            || (gameObject.CompareTag("HazardIcon") && GameCore.CurrentWeaponType == WeaponType.Acid)
            || (gameObject.CompareTag("PlasmaIcon") && GameCore.CurrentWeaponType == WeaponType.Plasma)
            || (gameObject.CompareTag("LaserIcon") && GameCore.CurrentWeaponType == WeaponType.Laser)
            || (gameObject.CompareTag("RocketIcon") && GameCore.CurrentWeaponType == WeaponType.Rocket)
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
        objectTrananform.position = Vector3.Lerp(objectTrananform.position, OnScreenPosition, Time.fixedDeltaTime * speed);
        if (objectTrananform.position.z >= (OnScreenPosition.z - 0.1f) && objectTrananform.position.z <= (OnScreenPosition.z + 0.1f))
            rigidbody.velocity = Vector3.zero;
    }

    private void HideBonus()
    {
        rigidbody.velocity = Vector3.zero;
        objectTrananform.position = Vector3.Lerp(objectTrananform.position, HidePosition, Time.fixedDeltaTime * speed);
        if (objectTrananform.position.z >= (HidePosition.z - 0.2f) && objectTrananform.position.z <= (HidePosition.z + 0.2f))
            Destroy(gameObject);
    }

    IEnumerator BonusLifeTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isBonusShown = true;
    }
}
