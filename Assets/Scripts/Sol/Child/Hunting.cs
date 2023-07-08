using Game.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hunting : MonoBehaviour
{
    [SerializeField] private float huntInterval = 90;
    [SerializeField] private float huntDuration = 30;
    private float huntTime;
    private bool hunting;
    [SerializeField] NavMeshAgent agent;

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

    void HutingPlayerState()
    { 
            agent.SetDestination(PlayerManager.Instance.transform.position);
    }

    IEnumerator StartHunt()
    {
        hunting = true;
        HutingPlayerState();
        yield return new WaitForSeconds(huntDuration);
        hunting = false;
    }
}
