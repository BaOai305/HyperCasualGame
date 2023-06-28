using Assets.Script.Core.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GamePlayUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button btnFire;
    private Button btnSwitchWepPre;

    [Header("Events")]
    private GameEvent onFire;
    private GameEvent onSwitchWepPre;
    void Start()
    {
        btnFire = GameObject.Find(CONST.UI_COMPONENT_NAME_BTN_FIRE).GetComponent<Button>();
        btnSwitchWepPre = GameObject.Find(CONST.UI_COMPONENT_NAME_BTN_SWITCH_WEP_PRE).GetComponent<Button>();
        setupButtons();
        setupEvents();
    }

    private void setupEvents()
    {
        onFire = Resources.Load<GameEvent>(CONST.PATH_EVENT_FIRE);
        onSwitchWepPre = Resources.Load<GameEvent>(CONST.PATH_EVENT_SWITCH_WEAPON);

    }

    private EventTrigger firee;
    private float holdFireTime = 0f;
    private void setupButtons()
    {
        //btnFire.onClick.AddListener(Fire);
        firee = btnFire.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { Fire(); });
        firee.triggers.Add(entry);
        // point up
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) => { StopFire(); });
        firee.triggers.Add(entry);

        btnSwitchWepPre.onClick.AddListener(SwitchWeaponPre);
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
        Debug.Log("Raise Fire");
    }
    private void StopFire()
    {
        isFiring = false;
    }

    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (isFiring) holdFireTime += Time.deltaTime;
        else holdFireTime = 0f;
        ///Debug.Log("isFiring: " + isFiring + ": holdFire: " + holdFireTime);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ((IPointerDownHandler)btnFire).OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ((IPointerUpHandler)btnFire).OnPointerUp(eventData);
    }
    //public void OnEventRaised(Component sender, object data)
    //{
    //    if (data is string) Debug.Log("OnEventRaised in UI: " + (string)data);
    //    else Debug.Log("OnEventRaised in UI");
    //}
}
