using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class InfoBoxGrabable : MonoBehaviour
{
    
    private void Start()
    {
        var grabber = GetComponent<XRGrabInteractable>();
        grabber.selectEntered.AddListener(OnGrabbed);
        grabber.selectExited.AddListener(OnGrabbStop);
    }

    public void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log($"I've been grabbed, {args.interactorObject.transform.gameObject.tag}");
    }

    public void OnGrabbStop(SelectExitEventArgs arg0)
    {
        Debug.Log("Exit");
    }
}
