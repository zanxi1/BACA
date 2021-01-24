using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	public Transform player;

	public float force = 100f;

	private void FixedUpdate() {
		if (Input.GetKey("d")) {
			rb.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		if (Input.GetKey("a")) {
			rb.AddForce(-force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		if (Input.GetKey("w")) {
			rb.AddForce(0, 0, force * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey("s")) {
			rb.AddForce(0, 0, -force * Time.deltaTime, ForceMode.VelocityChange);
		}
	}

}
