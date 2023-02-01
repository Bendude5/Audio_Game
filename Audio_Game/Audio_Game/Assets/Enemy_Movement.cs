using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public float speed;

    public bool chasePlayer;

    Vector3 playerLocation;
    Vector3 wayPointLocation;

    GameObject[] spawnPoints;
    GameObject currentPoint;
    Transform locations;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Floor_Centre");
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        //locations.x = currentPoint.transform.position.x;
        wayPointLocation.x = currentPoint.transform.position.x;
        wayPointLocation.y = currentPoint.transform.position.y;
        wayPointLocation.z = currentPoint.transform.position.z;
        print(currentPoint.name);
        Debug.Log(spawnPoints);
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation.x = player.position.x;
        playerLocation.y = player.position.y;
        playerLocation.z = player.position.z;
        agent.speed = speed;
        agent.SetDestination(wayPointLocation);

        if (agent.transform.position.x == currentPoint.transform.position.x || agent.transform.position.z == currentPoint.transform.position.z)
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("Floor_Centre");
            index = Random.Range(0, spawnPoints.Length);
            currentPoint = spawnPoints[index];
            //locations.x = currentPoint.transform.position.x;
            wayPointLocation.x = currentPoint.transform.position.x;
            wayPointLocation.y = currentPoint.transform.position.y;
            wayPointLocation.z = currentPoint.transform.position.z;
            print(currentPoint.name);
            Debug.Log(spawnPoints);
        }

        //if (agent.transform.position.x < currentPoint.transform.position.x + 1.0f && agent.transform.position.x > currentPoint.transform.position.x + 1.0f)
        //{
        //    Debug.Log("Reached waypoint");
        //}

        if (chasePlayer == true)
        {
            agent.SetDestination(playerLocation);
        }

        if (chasePlayer == false)
        {
            agent.SetDestination(wayPointLocation);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    switch (other.gameObject)
    //    {
    //        //This checks to see if the collision made was with player attack
    //        case "currentPoint";

    //            Debug.Log("Collided");
    //            break;
    //    }
    //}
}
