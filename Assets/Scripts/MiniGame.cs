using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGame : MonoBehaviour
{
    [Header("Base UI")]
    [SerializeField] Button startBtn;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI timeTxt;

    private int score = 0;

    public int Score {
        get {
            return score;
        }

        set {
            score = value;
            if (scoreTxt != null)
                scoreTxt.text = string.Format("Score : {0}", score);
        }
    }

    protected bool isPlaying = false;
    float limitTime = 60f;

    public float LimitTime {
        get {
            return limitTime;
        }
        set {
            limitTime = value;
        }
    }

    float currTime = 0f;

    private void Awake() {
        startBtn.onClick.AddListener(GameStart);
    }

    public float CurrTime {
        get {
            return currTime;
        }
        set {
            if (timeTxt != null) {
                if (Mathf.Floor(currTime) != Mathf.Floor(value)) {
                    timeTxt.text = "Time : " + (limitTime - Mathf.Floor(value)).ToString();
                }
            }
            currTime = value;
        }
    }

    Coroutine playingCoroutine;

    protected virtual void GameStart() {
        if (isPlaying) return;
        
        if (playingCoroutine == null) {
            playingCoroutine = StartCoroutine(GamePlaying());
        }
        else {
            Debug.LogError("Game is already started");
        }
    }

    protected virtual void GameInit() {
        isPlaying = true;
        Score = 0;
    }

    protected virtual IEnumerator GamePlaying() {
        GameInit();

        while (isPlaying) {
            CurrTime += Time.deltaTime;

            OnGamePlaying();

            if (CurrTime> limitTime) {
                GameOver();
            }
            yield return null;
        }
    }

    protected virtual void OnGamePlaying() {

    }

    protected virtual void GameOver() {
        CurrTime = 0;
        isPlaying = false;

        StopCoroutine(playingCoroutine);
        playingCoroutine = null;

        startBtn.gameObject.SetActive(true);
        timeTxt.gameObject.SetActive(false);
    }

    protected virtual void AddScore() {
        if (!isPlaying) return;
        Score++;
    }

}
