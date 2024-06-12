using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AssemblyManager : MonoBehaviour
{
    [SerializeField] private List<XRSocketInteractor> socketValidators;
    [SerializeField] private List<GameObject> catapultParts;
    [SerializeField] private GameObject catapultProject;
    [SerializeField] private GameObject animatedCatapult;

    public void CheckForWin()
    {
        SoundManager.Instance.Play(clipIndex: 0);
        var isWin = socketValidators.All(s => s.isSelectActive && ValidateSocket(s));
        Debug.Log(isWin);
        if (isWin)
        {
            SoundManager.Instance.Play(clipIndex: 1);
            DOVirtual.DelayedCall(2f, () =>
            {
                animatedCatapult.SetActive(true);
                catapultProject.SetActive(false);
                foreach (var gameObject in catapultParts)
                {
                    gameObject.SetActive(false);
                }
            });
            DOVirtual.DelayedCall(2f,() => CatapultAnimator.Instance.PlayAnimation(CatapultAnimation.Charge)).SetLoops(3);
            DOVirtual.DelayedCall(10f,() => CatapultAnimator.Instance.PlayAnimation(CatapultAnimation.Release)).SetLoops(3);
        }
    }

    private bool ValidateSocket(XRSocketInteractor socket)
    {
        var validator = socket.gameObject.GetComponent<SocketValidator>();
        return socket.GetOldestInteractableSelected()?.transform?.gameObject == validator.targetObject;
    }
}
