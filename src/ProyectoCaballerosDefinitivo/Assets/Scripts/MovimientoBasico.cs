using UnityEngine;
using System.Collections;

public class MovimientoBasico : MonoBehaviour {
	private Rigidbody2D rb; 
	public float speed = 2;
	public float maxSpeed = 7;
	private Transform transform;
	
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ((Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0)) {
			mover ();
		}
	//	rotar ();
		
		
	}
	
	void mover(){ //Nunca sobrepasa la velocidad maxima, ni apretando dos botones a la vez. 

		if (Mathf.Abs (rb.velocity.x) > maxSpeed && Mathf.Abs(rb.velocity.y) > maxSpeed){

		}
		else if (Mathf.Abs(rb.velocity.x)> maxSpeed && Mathf.Abs (rb.velocity.y) < maxSpeed){
			rb.AddForce (new Vector3 (0, speed * Input.GetAxisRaw ("Vertical") * Time.deltaTime, 
			                        0));
		} else if (Mathf.Abs (rb.velocity.y) > maxSpeed && Mathf.Abs (rb.velocity.x) <maxSpeed) {
			rb.AddForce (new Vector3 (speed * Input.GetAxisRaw ("Horizontal") * Time.deltaTime, 0, 
			                          0));
		} 
		 
		else {
			rb.AddForce (new Vector3 (speed * Input.GetAxisRaw ("Horizontal") * Time.deltaTime,
				speed * Input.GetAxisRaw ("Vertical") * Time.deltaTime, 0));
		}

	}
	void rotar(){
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, -angle, 0);
	}

	float AngleBetweenPoints(Vector2 a, Vector2 b){
		return Mathf.Atan2 (a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
	
}
	
	
