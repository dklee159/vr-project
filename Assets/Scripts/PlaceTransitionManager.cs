using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaceTransitionManager : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private XROrigin origin;
    public FadeScreen fadeScreen;
    public void TransformCharacter(GameObject door) {
        fadeScreen.FadeIn();
        
        Vector3 teleportPos;
        if (door.name == "Door") {
            teleportPos = door.transform.position + new Vector3(0, 0, 1);
        } else {
            float height = origin.GetComponent<CharacterController>().height;
            teleportPos = door.transform.position + new Vector3(0, height, 0);
        }
        origin.MoveCameraToWorldLocation(teleportPos);
        origin.MatchOriginUpCameraForward(door.transform.up, door.transform.forward);
    }
}
