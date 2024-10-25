using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ZoneEntrance : MonoBehaviour {
    private XRBaseInteractable interactable;
    private bool activedUI = false;
    private float distanceFromDoor = 0f;
    private float triggeredDistance = 0f;
    [SerializeField] private XROrigin origin;
    [SerializeField] private int limitRange;

    private Vector3 centerVector;

    // Start is called before the first frame update
    [SerializeField] private GameObject entranceUI;
    void Start() {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(visibleUI);


        for (int i = 0; i < interactable.colliders.Count; i++) {
            centerVector += interactable.colliders[i].gameObject.transform.position;
        }
        centerVector = centerVector / 2f;
        // interactable.hoverExited.AddListener(notVisibleUI);
    }

    private void visibleUI(BaseInteractionEventArgs hover) {
        if (hover.interactorObject is XRRayInteractor) {
            if (!activedUI) {
                activedUI = true;
                entranceUI.SetActive(true);
                triggeredDistance = Vector3.Distance(centerVector, origin.transform.position);
            }
        }
    }

    public void notVisibleUI() {
        if (activedUI) {
            activedUI = false;
            entranceUI.SetActive(false);
        }
    }

    private void Update() {
        if (activedUI) {
            distanceFromDoor = Vector3.Distance(centerVector, origin.transform.position);
            if (triggeredDistance - distanceFromDoor < limitRange) {
                notVisibleUI();
            }
        }
    }
}
