using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hoe : MonoBehaviour
{

    [SerializeField] XRBaseController basec;
    Quaternion itemRotation;
    Quaternion previousRotation = Quaternion.identity;

    Vector3 angularVelocity;
    private void Update() {
        itemRotation = basec.transform.rotation;

        Quaternion deltaRotation = itemRotation * Quaternion.Inverse(previousRotation);

        previousRotation = itemRotation;

        deltaRotation.ToAngleAxis(out var angle, out var axis);

        angle *= Mathf.Deg2Rad;

        angularVelocity = (1.0f / Time.deltaTime) * angle * axis;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.parent.name == "HarvestSpots") {
            
            float dot = Vector3.Dot((other.ClosestPoint(transform.position) - transform.position).normalized, transform.up);

            if (angularVelocity.magnitude > 7 && dot > 0) {
                Debug.Log("touch");
                other.gameObject.GetComponent<HarvestSpot>().Discount();
            }
        }
    }
}
