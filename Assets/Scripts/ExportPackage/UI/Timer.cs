using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float time;
    private List<int> durations = new List<int>() { 60, 90, 120, 180, 240, 300, 1000 };
    private int durationIndex;

    void Start()
    {
        time = durations[durationIndex];
    }

    void Update()
    {
        if (durationIndex < 6) time -= Time.deltaTime;
        else EndGame();

        if(time <= 0)
        {
            durationIndex++;
            time = durations[durationIndex];
        }

        timerText.text = "0" + durationIndex.ToString() + ":00";
    }

    void EndGame()
    {
        print("Voce ganhou!");
    }
}
