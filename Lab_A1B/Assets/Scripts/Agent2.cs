using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent2 : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public GameObject agent1;
    public float speed = 5.0f;
    public float agent1DistanceThreshold = 3.0f;


    //public State currentState = State.ChasePlayer;
    //float distanceToPlayer;
    //float distanceToTarget;
    //float distanceToAgent1;

    // agent states:
    private enum State
    {

        ChasePlayer,
        ChaseTarget,
        Flee
    }
    private State currentState = State.ChasePlayer;
    void Update()
    {
       Vector3 DirectionP = (player.transform.position - transform.position).normalized;
       Vector3 DirectionA = (agent1.transform.position - transform.position).normalized;
       Vector3 DirectionT = (target.transform.position - transform.position).normalized;

       float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
       float distanceToAgent1 = Vector3.Distance(agent1.transform.position, transform.position);
       float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToPlayer > distanceToTarget && distanceToAgent1 >agent1DistanceThreshold)
        {
            currentState = State.ChaseTarget;

        }
        else if (distanceToPlayer < distanceToTarget && distanceToAgent1 > agent1DistanceThreshold)
        {
            currentState = State.ChasePlayer;
        }
        else
        {
            currentState = State.Flee;
        }

        switch (currentState)
        {
            case State.ChasePlayer:

                transform.position += DirectionP * speed *  Time.deltaTime;

                break;

            case State.ChaseTarget:

                transform.position += DirectionT * speed * Time.deltaTime;

                break;

            case State.Flee:

                transform.position -= DirectionA * speed * Time.deltaTime;

                break;
        }


    }
}