using Assets.Script.Core.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GamePlayUI : MonoBehaviour
{
    [Header("Touchable")]
    public Button btnFire;
    public Button btnSwitchWepPre;
    public Button btnJump;
    public Button btnRun;
    public Button btnReload;
    private DynamicJoystick joystick;

    [Header("Text & Image")]
    public TextMeshProUGUI textDebug;
    public TextMeshProUGUI textAmmoPool;
    public TextMeshProUGUI textAmmoCurrent;
    public Image imgWeap;
    public Image characterAvatar;
    public Image prgHealthbar;
    public TextMeshProUGUI textHealth;

    private GameEvent onFire;
    private GameEvent onStopFire;
    private GameEvent onSwitchWepPre;
    private GameEvent onMove;
    private GameEvent onJump;
    private GameEvent onRun;
    private GameEvent onRunStop;
    private GameEvent onReload;

    // EventTrigger
    private EventTrigger firee;
    private EventTrigger jump;
    private EventTrigger run;

    // Parameter
    private float holdFireTime = 0f;
    void Start()
    {
        setupButtons();
        setupEvents();
        setupJoyStick();
    }
    private void setupJoyStick()
    {
        joystick = GameObject.Find("Dynamic Joystick").GetComponent<DynamicJoystick>();
    }
    private void setupEvents()
    {
        onFire = Resources.Load<GameEvent>(CONST.PATH_EVENT_FIRE);
        onStopFire = Resources.Load<GameEvent>(CONST.PATH_EVENT_STOP_FIRE);
        onSwitchWepPre = Resources.Load<GameEvent>(CONST.PATH_EVENT_SWITCH_WEAPON);
        onMove = Resources.Load<GameEvent>(CONST.PATH_EVENT_MOVE);
        onJump = Resources.Load<GameEvent>(CONST.PATH_EVENT_JUMP);
        onRun = Resources.Load<GameEvent>(CONST.PATH_EVENT_RUN);
        onRunStop = Resources.Load<GameEvent>(CONST.PATH_EVENT_RUN_STOP);
        onReload = Resources.Load<GameEvent>(CONST.PATH_EVENT_RELOAD);
    }

    private void setupButtons()
    {
        btnSwitchWepPre.onClick.AddListener(SwitchWeaponPre);
        btnReload.onClick.AddListener(ReloadAmmunation);

        EventTriggerType pointUp = EventTriggerType.PointerUp;
        EventTriggerType pointDown = EventTriggerType.PointerDown;

        firee = btnFire.AddComponent<EventTrigger>();
        EventTrigger.Entry entryFire = new EventTrigger.Entry();
        entryFire.eventID = pointDown;
        entryFire.callback.AddListener((data) => { Fire(); });
        firee.triggers.Add(entryFire);
        entryFire = new EventTrigger.Entry();
        entryFire.eventID = pointUp;
        entryFire.callback.AddListener((data) => { StopFire(); });
        firee.triggers.Add(entryFire);

        jump = btnJump.AddComponent<EventTrigger>();
        EventTrigger.Entry entryJump = new EventTrigger.Entry();
        entryJump.eventID = pointDown;
        entryJump.callback.AddListener((data) => { Jump(); });
        jump.triggers.Add(entryJump);
        entryJump = new EventTrigger.Entry();
        entryJump.eventID = pointUp;
        entryJump.callback.AddListener((data) => { StopJump(); });
        jump.triggers.Add(entryJump);

        run = btnRun.AddComponent<EventTrigger>();
        EventTrigger.Entry entryRun = new EventTrigger.Entry();
        entryRun.eventID = pointDown;
        entryRun.callback.AddListener((data) => { Run(); });
        run.triggers.Add(entryRun);
        entryRun = new EventTrigger.Entry();
        entryRun.eventID = pointUp;
        entryRun.callback.AddListener((data) => { StopRun(); });
        run.triggers.Add(entryRun);

    }


    private void ReloadAmmunation() => onReload.Raise(this, "");

    private void Run() => onRun.Raise(this, "");

    private void StopRun() => onRunStop.Raise(this, "");

    private void Jump() => onJump.Raise(this, "PATH_EVENT_JUMP");

    private void StopJump()
    {
        Debug.Log("StopJump");
    }
    private void SwitchWeaponPre()
    {
        onSwitchWepPre.Raise(this, "PATH_EVENT_SWITCH_WEAPON");
    }
    private bool isFiring = false;
    protected void Fire()
    {
        onFire.Raise(this, "FromGameplayUI");
        isFiring = true;
    }
    private void StopFire()
    {
        onStopFire.Raise(this, "FromGameplayUI");
        isFiring = false;
    }
    void Update()
    {
    }
    private void FixedUpdate()
    {
        onMove.Raise(this, joystick.Direction);
        if (isFiring) holdFireTime += Time.fixedDeltaTime;
        else holdFireTime = 0f;
        if (isFiring && holdFireTime == 0) Fire();
        if (isFiring && holdFireTime > 0.05f) Fire();
    }
    public object setDebugText(string text)
    {
        textDebug.text = text;
        return null;
    }

    public object setAmmoPoolText(string text)
    {
        textAmmoPool.text = text;
        return null;
    }

    public object setAmmoCurrentText(string text)
    {
        textAmmoCurrent.text = text;
        return null;
    }

    internal void updateAmmo(int ammoCurrent, int ammoPool)
    {
        setAmmoCurrentText(ammoCurrent.ToString());
        setAmmoPoolText(ammoPool.ToString());
    }

    internal void updateWeaponImage(Sprite sprite)
    {
        imgWeap.sprite = sprite;
    }

    internal void updateCharacterAvatar(Sprite sprite)
    {
        characterAvatar.sprite = sprite;
    }

    internal void updateHealthBar(float healthCurr, float healthTotal)
    {
        float fillAmount = healthCurr / healthTotal;
        prgHealthbar.fillAmount = fillAmount;
        // change color follow fillAmount, green to red
        if (fillAmount > 0.5f) prgHealthbar.color = Color.Lerp(Color.yellow, Color.green, (fillAmount - 0.5f) * 2);
        else prgHealthbar.color = Color.Lerp(Color.red, Color.yellow, fillAmount * 2);
        textHealth.text = healthCurr.ToString() + "/" + healthTotal.ToString();
    }
}
