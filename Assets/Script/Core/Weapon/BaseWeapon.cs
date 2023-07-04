﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Script.Core.Weapon;
using UnityEngine;

namespace Assets.Script.Core.Weapon
{
    [Serializable]
    public class BaseWeapon : IBaseWeapon
    {
        // identity
        private string id;
        private string nameDisplay;

        // sprite
        private string spritePath;

        // position of attachment
        private Vector2 shellExtractor;
        private Vector2 muzzleExtractor;

        // stats
        private float bulletSpeed;
        private float attackDamage;
        private float fireRate;
        private float reloadTime;
        private float spreadAim;
        private float mass;


        // magazine
        private int ammoMax;
        private int ammoCurrent;

        // behavior
        private float moveSpeedMultiplier;
        private float jumpSpeedpMultiplier;

        // type of weapon
        private WeaponEnum.EWeaponType weaponType;
        private WeaponEnum.EAmmoType ammoType;
        private WeaponEnum.EWeaponState weaponState;
        private WeaponEnum.EFireMode[] fireMode;

        // constructor
        public BaseWeapon(string id, string nameDisplay, string spritePath, Vector2 shellExtractor,
            Vector2 muzzleExtractor, float bulletSpeed, float attackDamage, float fireRate, float reloadTime,
            float spreadAim, float mass, int ammoMax, int ammoCurrent, float moveSpeedMultiplier,
            float jumpSpeedpMultiplier, WeaponEnum.EWeaponType weaponType, WeaponEnum.EAmmoType ammoType,
            WeaponEnum.EWeaponState weaponState, WeaponEnum.EFireMode[] fireMode)
        {
            this.id = id;
            this.nameDisplay = nameDisplay;
            this.spritePath = spritePath;
            this.shellExtractor = shellExtractor;
            this.muzzleExtractor = muzzleExtractor;
            this.bulletSpeed = bulletSpeed;
            this.attackDamage = attackDamage;
            this.fireRate = fireRate;
            this.reloadTime = reloadTime;
            this.spreadAim = spreadAim;
            this.mass = mass;
            this.ammoMax = ammoMax;
            this.ammoCurrent = ammoCurrent;
            this.moveSpeedMultiplier = moveSpeedMultiplier;
            this.jumpSpeedpMultiplier = jumpSpeedpMultiplier;
            this.weaponType = weaponType;
            this.ammoType = ammoType;
            this.weaponState = weaponState;
            this.fireMode = fireMode;
        }


        public BaseWeapon() { }

        // getter and setter
        public string Id { get; set; }
        public string NameDisplay { get; set; }
        public string SpritePath { get; set; }
        public Vector2 ShellExtractor { get; set; }
        public Vector2 MuzzleExtractor { get; set; }
        public float BulletSpeed { get; set; }
        public float AttackDamage { get; set; }
        public float FireRate { get; set; }
        public float ReloadTime { get; set; }
        public float SpreadAim { get; set; }
        public float Mass { get; set; }
        public int AmmoMax { get; set; }
        public int AmmoCurrent { get; set; }
        public float MoveSpeedMultiplier { get; set; }
        public float JumpSpeedpMultiplier { get; set; }
        public WeaponEnum.EWeaponType WeaponType { get; set; }
        public WeaponEnum.EAmmoType AmmoType { get; set; }
        public WeaponEnum.EWeaponState WeaponState { get; set; }
        public WeaponEnum.EFireMode[] FireMode { get; set; }

    }
}
