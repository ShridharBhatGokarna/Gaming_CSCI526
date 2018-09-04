using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private float speed;
	private Vector2 direction;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	GetInput(); 
	Move();
	}

	public void Move(){
	
 	transform.Translate(direction*speed*Time.deltaTime);
	}

	private void GetInput()
	{

	direction = Vector2.zero;
	
	if(Input.GetKey(KeyCode.W)){
		direction += Vector2.up;
	
	}
	
	else if(Input.GetKey(KeyCode.A)){
		direction += Vector2.left;
	}
	
	else if(Input.GetKey(KeyCode.S)){
		direction += Vector2.down;
	}

	else if(Input.GetKey(KeyCode.D)){
		direction += Vector2.right;
	}
	

	}	
}
