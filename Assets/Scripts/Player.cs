using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 4f;
	Animator anim;
	Rigidbody2D rb2d;
	Vector2 movement;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		movement = new Vector2(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical")
		);
		
		/* 
		transform.position = Vector3.MoveTowards(
			transform.position,
			transform.position + movement,
			speed * Time.deltaTime
		);
		*/

		if (movement != Vector2.zero) {
			anim.SetFloat("movX", movement.x);
			anim.SetFloat("movY", movement.y);
			anim.SetBool("walking", true);
		} else
		{
			anim.SetBool("walking", false);
		}
		
	}

	void FixedUpdate () {
		rb2d.MovePosition(rb2d.position + movement * speed * Time.deltaTime);
	}
}
