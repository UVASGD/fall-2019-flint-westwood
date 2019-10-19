using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> eventListeners = new List<GameEventListener>();

    public void Raise()
    {
        foreach (var listener in eventListeners)
        {
            listener.OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener eventListener)
    {
        eventListeners.Add(eventListener);
    }

    public void UnregisterListener(GameEventListener eventListener)
    {
        eventListeners.Remove(eventListener);
    }
}
