﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float m_speed = 0.1f;

	private Camera myCam;

	// Use this for initialization
	void Start () {
		myCam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		myCam.orthographicSize = (Screen.height / 25f) / 4f;

		if (target) {

			transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0,0, -10);

		}
	}
}
