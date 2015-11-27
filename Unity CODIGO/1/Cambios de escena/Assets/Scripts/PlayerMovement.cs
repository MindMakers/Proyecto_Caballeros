using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	private Rigidbody2D rbody;
	private Animator anim;

	public float speed;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		anim.SetFloat ("input_x", movement.x);
		anim.SetFloat ("input_y", movement.y);

		rbody.MovePosition (rbody.position + movement * speed * Time.deltaTime);

	}
}
