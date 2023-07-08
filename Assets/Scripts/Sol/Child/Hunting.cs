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
    [SerializeField] GameObject player;

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
        HutingPlayerState();
    }

    void HutingPlayerState()
    {
        Debug.Log("passou aqui");
        agent.SetDestination(player.transform.position);
        Debug.Log("player position: " + player.transform.position);
    }

    IEnumerator StartHunt()
    {
        hunting = true;
        

        yield return new WaitForSeconds(huntDuration);
        hunting = false;
    }
}
