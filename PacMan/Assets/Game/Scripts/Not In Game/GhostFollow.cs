using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : MonoBehaviour {

    private Transform target;

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;
    


	void Start () {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        //GhostFollow the player
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	
	void Update () {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else {
                waitTime -= Time.deltaTime;
            }

        }

	}//End Update


    private void OnTriggerEnter2D(Collider2D collision){

        //Kill player on contact
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
        }

    }



} //End Class


