using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVar : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [NonSerialized] public float runtimeValue;

    public void OnBeforeSerialize()
    {
       
    }

    public void OnAfterDeserialize()
    {
        this.runtimeValue = this.initialValue;
    }
    
}
