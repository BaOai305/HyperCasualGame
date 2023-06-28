using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Script.Core.Library;
using Assets.Script.Core.Weapon;
using UnityEngine.Windows;
using System.Runtime.Serialization.Json;
using System.IO;
using BayatGames.SaveGameFree.Serializers;
using BayatGames.SaveGameFree;

public class MainMenuController : MonoBehaviour
{
    private Button btnContinue;
    private Button btnNewGame;
    private Button btnLoadGame;
    private Button btnSetting;
    private Button btnQuit;

    private void Start()
    {
        btnContinue = GameObject.Find("btnContinue").GetComponent<Button>();
        btnNewGame = GameObject.Find("btnNewGame").GetComponent<Button>();
        btnLoadGame = GameObject.Find("btnLoadGame").GetComponent<Button>();
        btnSetting = GameObject.Find("btnSettings").GetComponent<Button>();
        btnQuit = GameObject.Find("btnQuit").GetComponent<Button>();

        btnContinue.onClick.AddListener(ContinueGame);
        btnNewGame.onClick.AddListener(NewGame);
        btnLoadGame.onClick.AddListener(LoadGame);
        btnSetting.onClick.AddListener(Setting);
        btnQuit.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        throw new NotImplementedException();
    }

    public BaseWeapon[] listWeapon;

    private void Setting()
    {
        listWeapon = SaveGame.Load<BaseWeapon[]>("WeaponConfig", new BaseWeapon[0], new SaveGameJsonSerializer());
        foreach (BaseWeapon weap in listWeapon)
        {
            Debug.Log(weap.NameDisplay);
        }
    }

    private void LoadGame()
    {
        weap = SaveGame.Load<BaseWeapon>("weapon", new BaseWeapon(), new SaveGameJsonSerializer());
        Debug.Log(weap.NameDisplay);

        FileInfo[] files = SaveGame.GetFiles();
        foreach (FileInfo file in files)
        {
            Debug.Log("file: "+file.Name);
        }
        // Log to path of saved game
        Debug.Log(SaveGame.SavePath.ToString());
    }

    private void NewGame()
    {
        GenerateConfig();
    }
    public BaseWeapon weap;
    private void GenerateConfig()
    {
        weap.Id = "1";
        weap.NameDisplay = "ACM";
        weap.SpritePath = "Sprites/Weapons/Guns/AR/ACM";
        weap.AttackDamage = 10;
        weap.FireRate = 0.1f;
        weap.ReloadTime = 1;
        weap.SpreadAim = 0.1f;
        weap.Mass = 1;
        weap.AmmoTotal = 30;
        weap.AmmoCurrent = 0;
        weap.MoveSpeedMultiplier = 1.2f;
        weap.JumpSpeedpMultiplier = 1.5f;
        weap.WeaponType = WeaponEnum.EWeaponType.Rifle;
        weap.AmmoType = WeaponEnum.EAmmoType.Rifle;
        weap.WeaponState = WeaponEnum.EWeaponState.Idle;
        // fire mode have single and auto
        WeaponEnum.EFireMode[] fir = new WeaponEnum.EFireMode[2];
        fir[0] = WeaponEnum.EFireMode.Single;
        fir[1] = WeaponEnum.EFireMode.Auto;
        weap.FireMode = fir;
        var jsonSerializer = new SaveGameJsonSerializer();
        Debug.Log("weapon.name: " + weap.NameDisplay);
        SaveGame.Save<BaseWeapon>("WeaponConfig", weap, jsonSerializer);

       
    }

    private void ContinueGame()
    {
        StartCoroutine(LoadSceneMode(CONST.SCENE_TEST));
    }

    private IEnumerator LoadSceneMode(string nameScene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameScene);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading scene " + nameScene + " " + (asyncLoad.progress * 100) + "%");
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
