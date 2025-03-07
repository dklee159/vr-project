using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AutumnGameManager : MiniGame
{
    [Header("Controller Model")]
    [SerializeField] Transform rightController;
    [SerializeField] List<Transform> controllerInteractors;
    [SerializeField] Transform hoe;

    [Header("Crops Props")]
    [SerializeField] List<GameObject> cropPrefabs;
    [SerializeField] GameObject spotPrefab;
    [SerializeField] List<Transform> harvestSpots;

    protected override void GameInit() {
        base.GameInit();

        SwitchingControllerModel(false);

        for (int i = 0; i < harvestSpots.Count; i++) {
            SpawnSpot(i);
        }
    }

    protected override IEnumerator GamePlaying() {
        yield return rightController.GetComponent<XRBaseController>().model;

        yield return base.GamePlaying();
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

        hoe.gameObject.SetActive(!isController);
    }

    private void SpawnSpot(int index) {
        Vector3 spawnPos = harvestSpots[index].transform.position;

        GameObject crop = Instantiate(spotPrefab, spawnPos, Quaternion.identity, harvestSpots[index].parent);
        crop.GetComponent<HarvestSpot>().OnHarvest += AddScore;
        crop.GetComponent<HarvestSpot>().OnHarvest += () => {
            int cropIndex = index / 6;

            Instantiate(cropPrefabs[cropIndex], crop.transform.position, Quaternion.identity);
        };
    }
}
