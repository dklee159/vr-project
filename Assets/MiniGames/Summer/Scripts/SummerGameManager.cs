using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SummerGameManager : MiniGame
{
    [Header("Controller Model")]
    [SerializeField] Transform rightController;
    [SerializeField] List<Transform> controllerInteractors;
    [SerializeField] Transform bugNetPrefab;

    [Header("Probs")]
    [SerializeField] GameObject butterflyPrefab;
    [SerializeField] List<Transform> butterflySpawnSpots;
    [SerializeField] GameObject spawnedButterflys;

    //List<GameObject> spawnedButterfly = new List<GameObject>();

    float spawnTime = 1f;
    float spawnCurrTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        bugNetPrefab.GetComponentInChildren<BugNet>().OnCatch += AddScore;
    }

    protected override void GameInit() {
        base.GameInit();
        LimitTime = 120;

        SwitchingControllerModel(false);
    }

    protected override IEnumerator GamePlaying() {
        yield return rightController.GetComponent<XRBaseController>().model;

        yield return base.GamePlaying();
    }

    protected override void OnGamePlaying() {
        spawnCurrTime += Time.deltaTime;

        if (spawnCurrTime > spawnTime) {
            spawnCurrTime = 0;
            RandomSpawn();
        }
    }

    protected override void GameOver() {
        base.GameOver();

        SwitchingControllerModel(true);
    }

    private void SwitchingControllerModel(bool isController) {
        // true : controller
        // false : bug net
        rightController.GetComponent<XRBaseController>().model.gameObject.SetActive(isController);
        rightController.GetComponent<XRBaseController>().enableInputActions = isController;

        foreach (Transform item in controllerInteractors) {
            item.gameObject.SetActive(isController);
        }

        bugNetPrefab.gameObject.SetActive(!isController);
    }

    private void RandomSpawn() {
        Transform randomTransform = butterflySpawnSpots[(Random.Range(0 ,butterflySpawnSpots.Count))].transform;
        Quaternion rot = Quaternion.Euler(-90, 0, randomTransform.eulerAngles.y - 90);

        Instantiate(butterflyPrefab, randomTransform.position, rot, spawnedButterflys.transform);
    }
}
