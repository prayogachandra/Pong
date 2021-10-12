using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour {
	public PlayerControl player;
	[SerializeField]
	public GameManager gameManager;
	void OnTriggerEnter2D(Collider2D anotherCollider){
		if(anotherCollider.name == "ball"){
			player.IncrementScore ();
			if(player.Score < gameManager.maxScore){
				anotherCollider.gameObject.SendMessage ("RestartGame",2.0f,SendMessageOptions.RequireReceiver);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
