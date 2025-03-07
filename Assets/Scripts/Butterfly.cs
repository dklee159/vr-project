using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    float speed = 0.5f;
    float upDown = 0;
    int changeSignTime = 1;
    int upDownSign = 1;

    private void Start() {
        Destroy(gameObject, 60);
    }

    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * speed, Space.World);
        transform.Translate(transform.up * upDownSign * Time.deltaTime * speed / 2);

        upDown += Time.deltaTime;
        if (upDown > changeSignTime) {
            upDown = 0;
            upDownSign *= -1;
        }
    }
}
