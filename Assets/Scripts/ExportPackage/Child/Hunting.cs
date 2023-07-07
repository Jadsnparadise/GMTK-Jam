using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting : MonoBehaviour
{
    [SerializeField] private float huntInterval;
    [SerializeField] private float huntDuration;
    private float huntTime;
    [SerializeField] private bool hunting;

    void Start()
    {
        huntTime = huntInterval;
    }

    void Update()
    {
        huntTime -= Time.deltaTime;
        if(huntTime <= 0)
        {
            huntTime = huntInterval;
            if (!hunting) StartCoroutine(StartHunt());
        }
    }

    IEnumerator StartHunt()
    {
        hunting = true;
        yield return new WaitForSeconds(huntDuration);
        hunting = false;
    }
}
