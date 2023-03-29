using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HyenaScript : MonoBehaviour
{
    public NavMeshAgent nma;

    float newPositionTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newPositionTimer -= Time.deltaTime;
        if (newPositionTimer < 0)
        {
            newPositionTimer = Random.Range(1, 5);
            Vector3 randomPosition = RandomNavMeshLocation(Random.Range(15, 80));
            nma.SetDestination(randomPosition);
        }
    }

    public Vector3 RandomNavMeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }
}
