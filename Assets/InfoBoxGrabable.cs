#nullable enable
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(XRGrabInteractable))]
public class InfoBoxGrabable : MonoBehaviour
{
    [SerializeField] private GameObject infoPopup = null!;
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
        }
    }

    private void OnGrabStop(SelectExitEventArgs arg0)
    {
        Debug.Log("Exit");
        infoPopup.SetActive(false);
    }
}
