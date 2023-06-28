using Assets.Script.Core.Weapon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WeaponEnum;

public class WeaponController : MonoBehaviour
{
    private BaseWeapon weaponStat;

    public BaseWeapon WeaponStat { get; set; }

    //public EWeaponState GetState() => weaponStat.WeaponState;

    public delegate void TaskCallBack(Component sender, object result);

    public void OnFire(TaskCallBack taskCallBack)
    {
        // spawn bullet
        GameObject bullet = new GameObject("Bullet");
        bullet.transform.position = transform.position;
        BulletController buc = bullet.AddComponent<BulletController>();

        BaseAmmo ammo = new BaseAmmo();
        ammo.AmmoType = WeaponStat.AmmoType;
        ammo.Damage = WeaponStat.AttackDamage;
        buc.AmmoStat = ammo;




        Debug.Log("I have started new Task.");
        Debug.Log("ammo: " + WeaponStat.AmmoCurrent.ToString());
        if (taskCallBack != null)
            taskCallBack(this, "I have completed Task.");
    }

}
