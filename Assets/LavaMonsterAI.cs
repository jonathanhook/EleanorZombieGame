using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LavaMonsterAI : MonoBehaviour
{
    private enum BehaviourState
    {
        WANDERING, CHASING
    }

    private NavMeshAgent agent;
    private BehaviourState state;
    private bool hasDestination;
    private GameObject hero;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = BehaviourState.WANDERING;
        hasDestination = false;

        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    void Update()
    {
        if(state == BehaviourState.WANDERING)
        {
            if(!hasDestination || agent.remainingDistance <= 1.0f)
            {
                float x = Random.Range(0, 100.0f);
                float z = Random.Range(0, 100.0f);

                agent.SetDestination(new Vector3(x, 0.0f, z));
                hasDestination = true;
            }
        }
        else if(state == BehaviourState.CHASING)
        {
            agent.SetDestination(hero.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hero = other.gameObject;
            state = BehaviourState.CHASING;
        }
    }
}
