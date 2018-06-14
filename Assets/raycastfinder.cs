using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastfinder : MonoBehaviour {

    private Vector2 dir = new Vector2(-1, 0);
    public float range;
    public float speed;
    public GameObject[] flagtargets;
    public GameObject[] flaglist;


    // Bit shift the index of the layer (8) to get a bit mask
    int layerMask = 1 << 8;

    // This would cast rays only against colliders in layer 8.
    // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
    

    // Use this for initialization
    void Start () {

        layerMask = ~layerMask;

        flaglist = GameObject.FindGameObjectsWithTag("flag");
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < flaglist.Length; i++) 
        {
            Vector2 direction = flaglist[i].transform.position - transform.position;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask);
            Debug.Log(hit.transform.gameObject.name);
            if (hit == true)
            {
             if (hit.transform.gameObject.tag == "flag")
                {
                    Debug.Log(hit.transform.gameObject.name);
                }
            }
        }

	}
    void FixedUpdate()
    {
        //rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
