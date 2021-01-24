using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FollowPlayer : MonoBehaviour {

    public Transform playerTransform;
    public Vector3 offset;
    public float turnSpeed = 4f;

    void Update() {
        transform.position = playerTransform.position + offset;

    }

    void LateUpdate() {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = playerTransform.position + offset;
        transform.LookAt(playerTransform.position);
    }

    public void setTarget(Transform target) {
        playerTransform = target;
	}
}
