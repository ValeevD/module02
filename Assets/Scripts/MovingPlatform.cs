using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject waypointsParent;

    public float speed;

    private float currentDistance; // от 0 до 1
    private int currentWaypoint;
    private Vector3 dir;
    private List<Transform> gameObjects;

    void Start()
    {
        gameObjects = new List<Transform>();
        waypointsParent.GetComponentsInChildren<Transform>(gameObjects);

        gameObjects.Remove(waypointsParent.transform);

        //Debug.Log(gameObjects.Count);

        currentWaypoint = 0;
        currentDistance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance += speed * Time.deltaTime;
        if(currentDistance > 1.0f)
        {
            currentWaypoint = (currentWaypoint + 1) % gameObjects.Count;
            currentDistance = 0;
        }

        transform.position = Vector3.Lerp(gameObjects[currentWaypoint].position, gameObjects[(currentWaypoint + 1) % gameObjects.Count].position, currentDistance);
    }
}
