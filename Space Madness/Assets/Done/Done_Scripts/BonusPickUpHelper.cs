using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class BonusPickUpHelper : MonoBehaviour
{
    public GameObject bonusPiskUpEffect;
    public GameObject bonusIcon;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (bonusPiskUpEffect != null)
                Instantiate(bonusPiskUpEffect, other.transform.position, Quaternion.identity);

            if (bonusIcon != null)
                Instantiate(bonusIcon, new Vector3(-10, -10, -10), Quaternion.identity);

            SetCurrentBonus();
            Destroy(gameObject);
        }
    }

    private void SetCurrentBonus()
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
            case "BonusAddLife(Clone)":
                GameCore.LifeCount++;
                break;
        }
    }
}
