using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class BonusPickUpHelper : MonoBehaviour
{
    public GameObject bonusPiskUpEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && bonusPiskUpEffect != null)
        {
            Vector3 position = other.transform.position;
            position.y = position.y + 0;
            Transform child = Instantiate(bonusPiskUpEffect, position, Quaternion.identity) as Transform;

            Debug.Log(gameObject.name);
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
        }
    }
}
