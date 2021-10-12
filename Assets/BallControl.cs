using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
	//Rigidbody 2D Bola
	private Rigidbody2D rigidBody2D;

	//besarnya gaya awal yang diberikan untuk mendorong bola
	public float xInitialForce;
	public float yInitialForce;

	private Vector2 trajectoryOrigin;
	void ResetBall(){
		//Reset posisi menjadi (0.0)
		transform.position = Vector2.zero;

		//Reset kecepatan menjadi (0.0)
		rigidBody2D.velocity = Vector2.zero;
	}

	void PushBall(){
		float yRandomInitialForce = Random.Range(-yInitialForce,yInitialForce);
		float randomDirection = Random.Range(0,2);
		if (randomDirection < 1.0f) {
			rigidBody2D.AddForce(new Vector2(-xInitialForce,yRandomInitialForce));
		} else {
			rigidBody2D.AddForce(new Vector2(xInitialForce,yRandomInitialForce));
		}
	}

	void RestartGame(){
		ResetBall();
		Invoke("PushBall", 2);
	}

	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		RestartGame();
		trajectoryOrigin = transform.position;
	}

	private void OnCollisionExit2D(Collision2D collision){
		trajectoryOrigin = transform.position;
	}

	public Vector2 TrajectoryOrigin{
		get{ return trajectoryOrigin;}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
