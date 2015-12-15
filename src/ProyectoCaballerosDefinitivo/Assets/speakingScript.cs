using UnityEngine;
using System.Collections;

public class speakingScript : MonoBehaviour {





	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Habla")) {
			other.gameObject.GetComponent<iSpeak> ().OnTriggerCall ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Habla")) {
			other.gameObject.gameObject.GetComponent<iSpeak> ().onTriggerFuera ();
		
		}



	}
}
