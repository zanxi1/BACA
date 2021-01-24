using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : MonoBehaviour {//NetworkBehaviour {

	public Rigidbody playerRigidBody;
	public float moveForce = 100f;

	private void FixedUpdate() {
		//if (!isLocalPlayer)
		//	return;

		if (Input.GetKey("w")) {
			playerRigidBody.AddForce(0, 0, moveForce * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey("s")) {
			playerRigidBody.AddForce(0, 0, -moveForce * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey("a")) {
			playerRigidBody.AddForce(-moveForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		if (Input.GetKey("d")) {
			playerRigidBody.AddForce(moveForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	}

}
