using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSocket : MonoBehaviour
{
    [SerializeField] private GameObject hoverIndicator = null!;

    private void Start()
    {
        hoverIndicator.SetActive(false);
        
    }

    public void OnObjectHover(XRBaseInteractable other)
    {
        hoverIndicator.SetActive(true);
    }
}
