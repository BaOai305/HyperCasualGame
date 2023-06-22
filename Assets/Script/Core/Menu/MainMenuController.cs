using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Script.Core.Library;

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

    private void Setting()
    {
        throw new NotImplementedException();
    }

    private void LoadGame()
    {
        throw new NotImplementedException();
    }

    private void NewGame()
    {
        throw new NotImplementedException();
    }

    private void ContinueGame()
    {
        // load to scene TestScene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(CONST.SCENE_TEST);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading...");
        }
    }
}
