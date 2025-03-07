using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class SnowBall : MonoBehaviour
{
    public UnityAction OnHit;
    bool canHit = false;
    
    void Start()
    {
        this.gameObject.GetComponent<XRGrabInteractable>().firstSelectEntered.AddListener(SnowBallSelectEnteredEvent);
        this.gameObject.GetComponent<XRGrabInteractable>().lastSelectExited.AddListener(SnowBallSelectExitedEvent);
    }

    public void SnowBallSelectEnteredEvent(SelectEnterEventArgs args) {
        args.interactorObject.transform.gameObject.GetComponent<XRRayInteractor>().attachTransform.localPosition = Vector3.zero;
    }
    public void SnowBallSelectExitedEvent(SelectExitEventArgs args) {
        canHit = true;
        Rigidbody rb = args.interactableObject.transform.gameObject.GetComponent<Rigidbody>();

        float mag = rb.angularVelocity.magnitude;
        Vector3 dir = args.interactorObject.transform.forward;

        rb.AddForce(dir * mag * 10);
    }

    private void OnCollisionEnter(Collision collision) {
        if (!canHit) return;
        canHit = false;
        if (collision.gameObject.transform.parent.name == "SnowMans") {
            if (collision.impulse.magnitude > 0) {
                OnHit.Invoke();
            }
        }
    }
}
