using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {
	public GameObject target;
	public float offsetX = 0, offsetY = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Late Update es el ultimo de los updates en llamarse, asi nos aseguramos de que el tio ya se ha movido
	void LateUpdate () {
		this.transform.position = new Vector3 (target.transform.position.x + offsetX, target.transform.position.y + offsetY, this.transform.position.z) ;
	}
}
