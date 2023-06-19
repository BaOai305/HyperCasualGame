using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Script.Core.Weapon;

namespace Assets.Script.Core.Weapon
{
    public class BaseWeapon
    {
        // identity
        private string id;
        private string nameDisplay;

        // stats
        private float attackDamage;
        private float fireRate;
        private float reloadTime;
        private float spreadAim;
        private float mass;

        // magazine
        private int ammoTotal;
        private int ammoCurrent;

        // behavior
        private float moveSpeedMultiplier;
        private float jumpSpeedpMultiplier;

        // type of weapon
        private WeaponEnum.EWeaponType weaponType;
        private WeaponEnum.EAmmoType ammoType;
        private WeaponEnum.EWeaponState weaponState;

        // constructor
        public BaseWeapon(string id, string nameDisplay, float attackDamage, float fireRate, float reloadTime, float spreadAim, float mass, int ammoTotal, int ammoCurrent, float moveSpeedMultiplier, float jumpSpeedpMultiplier, WeaponEnum.EWeaponType weaponType, WeaponEnum.EAmmoType ammoType, WeaponEnum.EWeaponState weaponState)
        {
            this.id = id;
            this.nameDisplay = nameDisplay;
            this.attackDamage = attackDamage;
            this.fireRate = fireRate;
            this.reloadTime = reloadTime;
            this.spreadAim = spreadAim;
            this.mass = mass;
            this.ammoTotal = ammoTotal;
            this.ammoCurrent = ammoCurrent;
            this.moveSpeedMultiplier = moveSpeedMultiplier;
            this.jumpSpeedpMultiplier = jumpSpeedpMultiplier;
            this.weaponType = weaponType;
            this.ammoType = ammoType;
            this.weaponState = weaponState;
        }

        public BaseWeapon() { }

        // getter and setter
        public string Id { get => id; set => id = value; }
        public string NameDisplay { get => nameDisplay; set => nameDisplay = value; }
        public float AttackDamage { get => attackDamage; set => attackDamage = value; }
        public float FireRate { get => fireRate; set => fireRate = value; }
        public float ReloadTime { get => reloadTime; set => reloadTime = value; }
        public float SpreadAim { get => spreadAim; set => spreadAim = value; }
        public float Mass { get => mass; set => mass = value; }
        public int AmmoTotal { get => ammoTotal; set => ammoTotal = value; }
        public int AmmoCurrent { get => ammoCurrent; set => ammoCurrent = value; }
        public float MoveSpeedMultiplier { get => moveSpeedMultiplier; set => moveSpeedMultiplier = value; }
        public float JumpSpeedpMultiplier { get => jumpSpeedpMultiplier; set => jumpSpeedpMultiplier = value; }
        public WeaponEnum.EWeaponType WeaponType { get => weaponType; set => weaponType = value; }
        public WeaponEnum.EAmmoType AmmoType { get => ammoType; set => ammoType = value; }
        public WeaponEnum.EWeaponState WeaponState { get => weaponState; set => weaponState = value; }


    }
}
