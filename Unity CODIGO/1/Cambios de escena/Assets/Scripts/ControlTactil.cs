using UnityEngine;
using System.Collections;

public class ControlTactil : MonoBehaviour {


	public float speed;

	private bool right = false;
	private bool left = false;
	private bool up = false;
	private bool down = false;
	private bool pause = false;

	public GameObject pauseMenuCanvas;

	private Rigidbody2D rbody;
	//private Animator anim;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		//anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (right) {
			rbody.transform.Translate(Vector3.right * Time.deltaTime * speed);
			//anim.SetFloat ("input_x", Vector3.right);
		}
		if (left) {
			rbody.transform.Translate(Vector3.left * Time.deltaTime * speed);
			//anim.SetFloat ("input_x", Vector3.left);
		}
		if (up) {
			rbody.transform.Translate(Vector3.up * Time.deltaTime * speed);
			//anim.SetFloat ("input_y", Vector3.up);
		}
		if (down) {
			rbody.transform.Translate(Vector3.down * Time.deltaTime * speed);
			//anim.SetFloat ("input_y", Vector3.down);
		}

	}

	public void MoverDerecha()
	{
		right = true;
	}
	
	public void MoverIzqda()
	{
		left = true;
	}
	
	public void MoverArriba()
	{
		up = true;
	}
	
	public void MoverAbajo()
	{
		down = true;
	}

	public void Pausar()
	{
		pause = true;
		pauseMenuCanvas.SetActive (true);
		Time.timeScale = 0f;
	}
	
	public void Detener()
	{
		right = false;
		left = false;
		up = false;
		down = false;
		pause = false;
	}


}
