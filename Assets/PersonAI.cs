using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonAI : MonoBehaviour
{
    public float runSpeed = 7.0f;

    private enum BehaviourState
    {
        WANDERING, RUNNING
    }

    private NavMeshAgent agent;
    private BehaviourState state;
    private AudioSource sound;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();

        state = BehaviourState.WANDERING;
        ChangeDestination();

        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    void Update()
    {
        if (state == BehaviourState.WANDERING)
        {
            if (agent.remainingDistance <= 1.0f)
            {
                ChangeDestination();
            }
        }
    }

    private void ChangeDestination()
    {
        float x = Random.Range(0, 100.0f);
        float z = Random.Range(0, 100.0f);

        agent.SetDestination(new Vector3(x, 0.0f, z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state == BehaviourState.WANDERING)
        {
            if (other.tag == "Player")
            {
                state = BehaviourState.RUNNING;
                agent.SetDestination(transform.position + Vector3.forward * 100.0f);
                agent.speed = runSpeed;
            }
            else if (other.tag == "Lava")
            {
                ChangeDestination();
            }
        }
        else if(state == BehaviourState.RUNNING)
        {
            if(other.tag == "Lava")
            {
                if (!sound.isPlaying)
                {
                    sound.Play();
                }
            }
        }
    }
}
