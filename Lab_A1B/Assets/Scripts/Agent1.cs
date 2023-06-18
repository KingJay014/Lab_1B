using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent1 : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float speed = 5.0f;
    public float playerDistanceThreshold = 5.0f;
    public float targetDistanceThreshold = 3.0f;

    private void Update()
    {
       
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        //Vector3 Direction = (transform.position - player.transform.position).normalized;

        bool targetActivated = targetDistance < targetDistanceThreshold;
        
        if (targetActivated && playerDistance < playerDistanceThreshold)
        {
            // Flee 
            transform.position -= transform.position * Time.deltaTime;
            Vector3 Direction = (player.transform.position - transform.position).normalized;
        }
        else
        {
            // Chase 
            transform.position += player.transform.position  * Time.deltaTime;
            Vector3 Direction = (player.transform.position - transform.position).normalized;
        }
    }
}
