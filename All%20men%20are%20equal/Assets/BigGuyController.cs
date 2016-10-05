using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public float jump = 8;
	public float throwSpeed = 50;

	float moveVelocity;
	private GameObject player2;
	bool onGround = true;
	bool throwReady;

	// Use this for initialization
	void Start () {
		player2 = GameObject.FindGameObjectWithTag("Player");
	}


	
	// Update is called once per frame
	void Update () {
		moveVelocity = 0;
		//left-right movements
		if (Input.GetKey(KeyCode.W))
        {	if(onGround){
        		//print(onGround);
        		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);  
        		//print(onGround);
        	}
        }
        if (Input.GetKey(KeyCode.D))
        {
        	moveVelocity = speed;
        }

        //jump
        if (Input.GetKey(KeyCode.A))
        {
        	moveVelocity = -speed;
        }

        if (Input.GetKey(KeyCode.LeftShift)){
        	if(throwReady){
        		player2.GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x,throwSpeed);
        	}
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity,GetComponent<Rigidbody2D>().velocity.y);
	
	}

	void OnTriggerEnter2D(Collider2D other){
		//print(onGround);
		if (other.gameObject.CompareTag("floor")){
			//print(onGround);
			onGround = true;
		}
		if (other.gameObject.CompareTag("Player")){
			throwReady = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag("floor")){
			//print(onGround);
			onGround = false;
		}
		if (other.gameObject.CompareTag("Player")){
			throwReady = false;
		}

	}
}
