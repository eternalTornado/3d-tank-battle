using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyboardHandler
{
    private Dictionary<KeyCode, Action> dictAction;

    private KeyCode[] listKeys;

    public KeyboardHandler()
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

    public bool IsAnyKey()
    {
        return Input.anyKey;
    }

    public bool IsAnyKeyDown()
    {
        return Input.anyKeyDown;
    }

    //This one works but only return one key at the time
    //We should be able to handle multiple inputs at a same time since this is kind of an action game
    //20/8: Ah so I figured we should keep both versions
    public KeyCode GetKeyPressed()
    {
        foreach (var key in listKeys)
            if (Input.GetKey(key))
                return key;

        return KeyCode.None;
    }

    public KeyCode GetKeyDown()
    {
        foreach (var key in listKeys)
            if (Input.GetKeyDown(key))
                return key;

        return KeyCode.None;
    }

    public List<KeyCode> GetKeysPressed()
    {
        var result = new List<KeyCode>();
        foreach (var key in listKeys)
            if (Input.GetKey(key))
                result.Add(key);

        return result;
    }

    public List<KeyCode> GetKeysDown()
    {
        var result = new List<KeyCode>();
        foreach (var key in listKeys)
            if (Input.GetKeyDown(key))
                result.Add(key);

        return result;
    }
}
