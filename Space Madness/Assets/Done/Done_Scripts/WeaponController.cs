using System;
using UnityEngine;
using AssemblyCSharp;

public class WeaponController : MonoBehaviour
{
    private float StartWeaponTime;
    private float NextFireTime;
    private Weapon CurrentWeapon;
    public Transform shotSpawn;
    public Weapon[] weapons;

    public float BonusWeaponLifeTime;

    void Start()
    {
        GameCore.WeaponStartTime = 0;
        CurrentWeapon = weapons[0];// was 0
        GameCore.CurrentWeaponType = WeaponType.Default;
        NextFireTime = Time.time + CurrentWeapon.PeriodBetweenShots;
    }

    void Update()
    {
        if (Time.time > NextFireTime && !GameCore.isShowStartCountDown)
        {
            Shoot();
        }
        ChangeWeaponIfItNeeded();
    }

    private void ChangeWeaponIfItNeeded()
    {
        if (GameCore.WeaponStartTime > Time.time - BonusWeaponLifeTime && GameCore.CurrentWeaponType != WeaponType.Default)
        {
            switch (GameCore.CurrentWeaponType)
            {
                case WeaponType.Default:
                    CurrentWeapon = weapons[0];
                    break;
                case WeaponType.Rocket:
                    CurrentWeapon = weapons[1];
                    break;
                case WeaponType.Laser:
                    CurrentWeapon = weapons[2];
                    break;
                case WeaponType.Plasma:
                    CurrentWeapon = weapons[3];
                    break;
                case WeaponType.Acid:
                    CurrentWeapon = weapons[4];
                    break;
            }
        }
        else
        {
            GameCore.CurrentWeaponType = WeaponType.Default;
            GameCore.WeaponStartTime = 0;
            CurrentWeapon = weapons[0];
        }
        if (audio.clip != CurrentWeapon.ShotSound)
            audio.clip = CurrentWeapon.ShotSound;
    }

    public void Shoot()
    {
        NextFireTime = Time.time + CurrentWeapon.PeriodBetweenShots * (AppCore.IsFastMotion ? 0.5f : 1f); ;
        Instantiate(CurrentWeapon.Bolt, shotSpawn.position, shotSpawn.rotation);
        audio.Play();
    }

    public void SetBonusWeapon(string weaponName)
    {
        foreach (Weapon w in weapons)
            if (w.Name == weaponName)
            {
                CurrentWeapon = w;
                break;
            }
    }
}

