using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HarvestSpot : MonoBehaviour
{
    public UnityAction OnHarvest;
    int cnt;

    public int Cnt {
        get {
            return cnt;
        }
        set {
            cnt = value;

            if (value == 0) {
                HarvestSuccess();
            }
        }
    }

    private void Start() {
        Cnt = Random.Range(3, 8);
    }

    private void HarvestSuccess() {
        OnHarvest.Invoke();
        gameObject.SetActive(false);
    }

    public void Discount() {
        Cnt--;
    }
}
