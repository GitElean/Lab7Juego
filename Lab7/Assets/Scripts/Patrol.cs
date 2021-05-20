using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour
{
    public Transform wpCont;

    List<Transform> waypoints;//lista de waypoints

    int cWP = 0;//waypoint actual

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        waypoints = new List<Transform>();

        //añadir los puntos a la lista a recorrer
        foreach (Transform child in wpCont)
            waypoints.Add(child);

        agent.SetDestination(waypoints[cWP].position);
    }

    // Update is called once per frame
    void Update()
    {
        //recorrer los waypoints en orden
        if(agent.remainingDistance < 0.2f)
        {
            cWP++;
            cWP = cWP % waypoints.Count;
            agent.SetDestination(waypoints[cWP].position);

        }
    }
}
