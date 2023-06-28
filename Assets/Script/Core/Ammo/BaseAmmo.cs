using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WeaponEnum;

public class BaseAmmo
{
    private EAmmoType ammoType;
    private float damage;

    public EAmmoType AmmoType { get; set; }
    public float Damage { get; set; }

    public BaseAmmo(EAmmoType ammoType, float damage)
    {
        AmmoType = ammoType;
        Damage = damage;
    }
    public BaseAmmo() { }
}
