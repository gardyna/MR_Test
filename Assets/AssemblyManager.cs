using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AssemblyManager : MonoBehaviour
{
    [SerializeField] private List<XRSocketInteractor> socketValidators;

    public void CheckForWin()
    {
        SoundManager.Instance.Play(clipIndex: 0);
        var isWin = socketValidators.All(s => s.isSelectActive && ValidateSocket(s));
        Debug.Log(isWin);
        if (isWin)
        {
            SoundManager.Instance.Play(clipIndex: 1);
        }
    }

    private bool ValidateSocket(XRSocketInteractor socket)
    {
        var validator = socket.gameObject.GetComponent<SocketValidator>();
        return socket.GetOldestInteractableSelected()?.transform?.gameObject == validator.targetObject;
    }
}
