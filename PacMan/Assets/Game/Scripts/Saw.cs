using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {

    private int r;

    public float min ;
    public float max ;
    
    // Use this for initialization
    void Start () {
        min = transform.position.x;
        max = transform.position.x + 3;
        r = Random.Range(2, 10);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.PingPong(Time.time * r, max - min) + min, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Kill player on contact
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            print("You are a fag");
        }

    }

}
