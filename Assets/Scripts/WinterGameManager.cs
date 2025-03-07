using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WinterGameManager : MiniGame
{
    [SerializeField] List<GameObject> snowBalls;

    private void Start() {
        foreach (GameObject item in snowBalls) {
            item.GetComponent<SnowBall>().OnHit += AddScore;
        }
    }
}
