#nullable enable
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;


[RequireComponent(typeof(XRGrabInteractable))]
public class InfoBoxGrabable : MonoBehaviour
{
    [SerializeField] private GameObject infoPopup = null!;
    private Tweener popupTween = null!;
    private void Start()
    {
        var grabber = GetComponent<XRGrabInteractable>();
        grabber.selectEntered.AddListener(OnGrabbed);
        grabber.selectExited.AddListener(OnGrabStop);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log($"I've been grabbed, {args.interactorObject.transform.gameObject.tag}");
        if (!args.interactorObject.transform.CompareTag("place"))
        {
            infoPopup.SetActive(true);
            ShowPopup();
        }
        else
        {
            HidePopup();
        }
    }

    private void OnGrabStop(SelectExitEventArgs arg0)
    {
        Debug.Log("Exit");
        
        HidePopup();
    }

    private void ShowPopup()
    {
        popupTween?.Kill();
        
        infoPopup.transform.localScale = Vector3.zero;
        popupTween = infoPopup.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
        SoundManager.Instance.Play(clipIndex:5);
    }

    private void HidePopup()
    {
        popupTween?.Kill();
        
        popupTween = infoPopup.transform.DOScale(Vector3.zero, 0.1f)
            .SetEase(Ease.OutSine)
            .OnComplete(() => infoPopup.SetActive(false));
    }
}
