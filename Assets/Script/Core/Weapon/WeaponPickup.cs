using Assets.Script.Core.Weapon;
using BayatGames.SaveGameFree.Serializers;
using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Core.Library;
using System;

// BaseWeapon[] weapons = SaveGame.Load<BaseWeapon[]>(CONST.FILE_WEAPON_CONFIG, new BaseWeapon[0], new SaveGameJsonSerializer());
public class WeaponPickup : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public string nameWeapon;
    private BaseWeapon weaponStat;

    private void OnValidate()
    {
    }

    private void Start()
    {
        weaponStat = getWeaponConfig(nameWeapon);
        setupWeapon(weaponStat);
    }

    public BaseWeapon getWeaponConfig(string nameWeapon)
    {
        BaseWeapon[] weapons = SaveGame.Load<BaseWeapon[]>(CONST.FILE_WEAPON_CONFIG, new BaseWeapon[0], new SaveGameJsonSerializer());
        foreach (BaseWeapon weapon in weapons)
        {
            if (weapon.NameDisplay == nameWeapon) return weapon;
        }
        return new BaseWeapon();
    }

    public void setupWeapon(BaseWeapon weapon)
    {
        spriteRenderer.sprite = Resources.Load<Sprite>(weapon.SpritePath);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == CONST.TAG_PLAYER)
        {
            collision.gameObject.GetComponent<CharacterController>().MeetObjectPickup(gameObject, weaponStat);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == CONST.TAG_PLAYER)
        {
            collision.gameObject.GetComponent<CharacterController>().ExitObjectPickup();
        }
    }
}