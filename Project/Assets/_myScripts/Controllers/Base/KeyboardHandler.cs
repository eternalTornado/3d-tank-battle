using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyboardHandler : MonoBehaviour
{
    private Dictionary<KeyCode, Action> dictAction;

    private KeyCode[] listKeys;
    private void Start()
    {
        listKeys = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
        dictAction = new Dictionary<KeyCode, Action>();
    }

    public void RegisterAction(KeyCode keyCode, Action action)
    {
        dictAction[keyCode] = action;
    }

    public void TriggerAction(KeyCode keyCode)
    {
        if (dictAction == null ||
            !dictAction.ContainsKey(keyCode))
        {
            return;
        }

        dictAction[keyCode]?.Invoke();
    }

    public KeyCode GetKeyPressed()
    {
        foreach (var key in listKeys)
            if (Input.GetKey(key))
                return key;

        return KeyCode.None;
    }
}
