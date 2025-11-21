using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnEnabled : MonoBehaviour
{
    public UnityEvent customEvent;

    private bool toggle = true;

    private void OnEnable()
    {
        if (toggle)
            customEvent.Invoke();
        
        Debug.Log("Unity Event invoked in " + gameObject.name);
        toggle = false;
    }

    private void OnDisable()
    {
        toggle = true;
    }

    public void DebugMessage()
    {
        Debug.Log("You've activated the DebugMessage in " + gameObject);
    }
}
