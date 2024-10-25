using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverFrame : MonoBehaviour
{
    private XRBaseInteractable interactable;
    [SerializeField] private bool activedUi = false;
    [SerializeField] private List<GameObject> frameLists;
    // private Outline outlineScript;
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(outlineVisibleOn);
        interactable.hoverExited.AddListener(outlineVisibleOff);
        interactable.activated.AddListener(visibleUI);
    }
    
    private void outlineVisibleOn(BaseInteractionEventArgs hover){
        if (hover.interactorObject is XRRayInteractor) {            
            this.GetComponent<Outline>().OutlineWidth = 10;
        }        
    }

    private void outlineVisibleOff(BaseInteractionEventArgs hover){
        if (hover.interactorObject is XRRayInteractor) {
            if (!activedUi) {                
                this.GetComponent<Outline>().OutlineWidth = 0;
            }
        }
    }

    private void visibleUI(BaseInteractionEventArgs hover){
        if (hover.interactorObject is XRRayInteractor) {
            activedUi = true;
            for (int i = 0; i < frameLists.Count; i++)
            {
                frameLists[i].GetComponent<HoverFrame>().activedUi = false;
                frameLists[i].GetComponent<Outline>().OutlineWidth = 0;
            }
        }
    }

    public void visibleUIoff(){
        activedUi = false;
        this.GetComponent<Outline>().OutlineWidth = 0;
    }
}
