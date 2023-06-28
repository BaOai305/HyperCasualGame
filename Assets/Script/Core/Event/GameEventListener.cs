using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CustomGameEvent : UnityEvent<Component, object>
{

}
public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;

    //public delegate void OnEventRaised();
    //public OnEventRaised onEventRaised;

    //public void OnEventRaisedMethod()
    //{
    //    onEventRaised?.Invoke();
    //}

    public CustomGameEvent response;

    private void OnEnable()
    {
        // for editor only
        gameEvent?.RegisterListener(this);
    }

    private void OnDisable()
    {
        // for editor only
        gameEvent?.UnregisterListener(this);
    }

    public void OnEventRaised(Component sender, object data)
    {
        response?.Invoke(sender, data);
    }

    // add listener event to response
    public void AddListener(UnityAction<Component, object> action)
    {
        response?.AddListener(action);
    }

    public void OnGameEventListenerEnable()
    {
        // for runtime only
        OnEnable();
    }

    public void OnGameEventListenerDisable()
    {
        // for runtime only
        OnDisable();
    }
}
