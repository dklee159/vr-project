using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BugNet : MonoBehaviour {
    public UnityAction OnCatch;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.parent.name == "Butterflys") {
            Vector3 point = other.ClosestPoint(gameObject.transform.position);
            Vector3 dir = (point - other.transform.position).normalized;
            float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(-transform.forward, dir));

            Debug.Log(angle);

            if (angle < 50) {
                OnCatch.Invoke();
                Destroy(other.transform.gameObject);
                Debug.Log("catch a butterfly");
            }
        }
    }
}
