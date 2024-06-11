using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InfoBoxGrabable : MonoBehaviour
{
    private void Start()
    {
        var Grabber = GetComponent<XRGrabInteractable>();
    }

    void OnGrabbed()
    {
        Debug.Log("I've been grabbed");
    }
}
