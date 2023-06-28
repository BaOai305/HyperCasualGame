using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/GameEvent", order = 1)]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners = new List<GameEventListener>();

    // Raise the event through different methods signature
    public void Raise(Component sender, object data)
    {
        for(int i=0; i<listeners.Count; i++)
        {
            listeners[i].OnEventRaised(sender, data);
            //listeners[i].OnEventRaisedMethod();
        }  
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if(listeners.Contains(listener)) listeners.Remove(listener);
    }
}
