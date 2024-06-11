using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"objects {transform.position}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
