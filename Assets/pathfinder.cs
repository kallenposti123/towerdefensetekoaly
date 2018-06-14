using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinder : MonoBehaviour {


    public bool goback = true;


    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
        float movespeed = 2f;

    

    int waypointIndex = 0;
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}


    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                         waypoints[waypointIndex].transform.position,
                         movespeed * Time.deltaTime);


        if (!goback && transform.position == waypoints [waypointIndex].transform.position)
        {
            waypointIndex += 1;

            if (waypointIndex == waypoints.Length) { goback = true; waypointIndex -= 1; }
                

        }

        if (goback && transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex -= 1;

            if (waypointIndex == -1) { goback = false; waypointIndex += 1; }
                

        }


    }

}
