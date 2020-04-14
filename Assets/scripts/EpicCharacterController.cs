using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpicCharacterController : MonoBehaviour {
    public float jumpSpeed = 5f;
    public float speed = 5.0f;
	private float distToGround;
    private Rigidbody rb;
    private EndGame ded;
    private Vector3 pos;
    private Quaternion rot;

    void Start () {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        ded = GetComponent<EndGame>();
        pos = transform.position;
        rot = transform.rotation;
	}
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape")) {
            // toggle the cursor
            if (Cursor.lockState == CursorLockMode.None) {
                Cursor.lockState = CursorLockMode.Locked;
            } else {
                Cursor.lockState = CursorLockMode.None;
            };
        }

        if (Input.GetButton("Jump") && isGrounded()) {
			Vector3 vel = rb.velocity;
            rb.velocity = new Vector3(vel.x, jumpSpeed, vel.z);
		}
    }

    bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

    /*public void Reset() {
         transform.position = pos;
         transform.rotation = rot;
    }*/
}