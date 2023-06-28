using Assets.Script.Core.Weapon;
using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree.Serializers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WeaponEnum;

public class Inventory
{
    private BaseWeapon[] weapons;
    private Dictionary<EAmmoType, int> ammoTotal;
    private Dictionary<EAmmoType, int> ammoCurrent;
    //void Start()
    //{
    //    weapons = SaveGame.Load<BaseWeapon[]>("WeaponConfig", new BaseWeapon[0], new SaveGameJsonSerializer());
    //}

    //void Update()
    //{

    //}

    public Inventory()
    {
        weapons = new BaseWeapon[0];
        ammoTotal = new Dictionary<EAmmoType, int>();
        ammoCurrent = new Dictionary<EAmmoType, int>();
    }

    // Singleton pattern
    private static Inventory instance;
    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Inventory();
            }
            return instance;
        }
    }

    public BaseWeapon getWeapon(int index)
    {
        return index < weapons.Length ? weapons[index] : null;
    }

    public BaseWeapon addWeapon(BaseWeapon baseWeapon)
    {
        //Debug.Log("add weapon");
        //Debug.Log("Length: " + weapons.Length);
        BaseWeapon[] temp = new BaseWeapon[weapons.Length + 1];
        for (int i = 0; i < weapons.Length; i++)
        {
            temp[i] = weapons[i];
        }
        temp[weapons.Length] = baseWeapon;
        weapons = temp;
        return baseWeapon;
    }

    // get length of weapons
    public int getWeaponLength()
    {
        return weapons.Length;
    }

    internal void setWeaponState(int index, EWeaponState equipping)
    {
        weapons[index].WeaponState = equipping;
    }
}
