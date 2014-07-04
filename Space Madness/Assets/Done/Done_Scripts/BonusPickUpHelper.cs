﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class BonusPickUpHelper : MonoBehaviour
{
    public GameObject bonusPiskUpEffect;
    public GameObject bonusIcon;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && bonusPiskUpEffect != null)
        {
            Vector3 position = other.transform.position;
            Transform child = Instantiate(bonusPiskUpEffect, position, Quaternion.identity) as Transform;

            Instantiate(bonusIcon, new Vector3(-10,-10,-10), Quaternion.identity);

            SetCurrentWeapon();
            Destroy(gameObject);
        }
    }

    private void SetCurrentWeapon()
    {
        switch (gameObject.name)
        {
            case "BonusWeapon_Rocket(Clone)":
                GameCore.CurrentWeaponType = WeaponType.Rocket;
                GameCore.WeaponStartTime = Time.time;
                break;
            case "BonusWeapon_Lazer(Clone)":
                GameCore.CurrentWeaponType = WeaponType.Laser;
                GameCore.WeaponStartTime = Time.time;
                break;
            case "BonusWeapon_Plasma(Clone)":
                GameCore.CurrentWeaponType = WeaponType.Plasma;
                GameCore.WeaponStartTime = Time.time;
                break;
            case "BonusWeapon_Hazard(Clone)":
                GameCore.CurrentWeaponType = WeaponType.Acid;
                GameCore.WeaponStartTime = Time.time;
                break;
            case "BonusOther_Guard(Clone)":
                AppCore.IsGodMod = true;
                break;
            case "BonusOther_Slow(Clone)":
                AppCore.IsSlowMotion = true;
                AppCore.IsFastMotion = false;
                break;
            case "BonusOther_Speed(Clone)":
                AppCore.IsSlowMotion = false;
                AppCore.IsFastMotion = true;
                break;
        }
    }
}
