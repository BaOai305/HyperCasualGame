using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class WeaponEnum 
{
    public enum EAmmoType
    {
        None,
        Circle,
        Round,
        Sharp
    }
    public enum EWeaponType
    {
        None,
        Pistol,
        SMG,
        Rifle,
        Shotgun,
        Sniper,
        Rocket,
        Grenade
    }

    public enum EFireMode
    {
        Single,
        Burst,
        Auto,
        Heavy
    }

    public enum EWeaponState
    {
        Idle,
        Firing,
        Reloading,
        Equipping,
        Unequipping
    }
}
