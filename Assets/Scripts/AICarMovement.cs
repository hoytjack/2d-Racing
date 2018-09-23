using UnityEngine;
using System.Collections;

public class AICarMovement : CarMovement {

	public float acceleration = 0.3f;
	public float braking = 0.6f;
	public float steering = 4.0f;
	private float timeLeftBraking = 0.0f;

	Vector3 target;

	public void OnNextTrigger(TrackLapTrigger next) {

		// choose a target to drive towards
		target = Vector3.Lerp(next.transform.position - next.transform.right, 
		                      next.transform.position + next.transform.right, 
		                      Random.value);
	}

	void SteerTowardsTarget ()
	{
		Vector2 towardNextTrigger = target - transform.position;
		float targetRot = Vector2.Angle (Vector2.right, towardNextTrigger);
		if (towardNextTrigger.y < 0.0f) {
			targetRot = -targetRot;
		}
		float rot = Mathf.MoveTowardsAngle (transform.localEulerAngles.z, targetRot, steering);
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, rot);
	}

	// update for physics
	void FixedUpdate() {
		if (timeLeftBraking > 0.0f) {
			timeLeftBraking -= Time.deltaTime;
		}
		SteerTowardsTarget();

		// always accelerate
		float velocity = GetComponent<Rigidbody2D>().velocity.magnitude;
		if (timeLeftBraking > 0.0f) {
			velocity -= braking;
			GetComponent<Rigidbody2D>().rotation += 3.0f;
		} else {
			velocity += acceleration;
		}
		// apply car movement
		GetComponent<Rigidbody2D>().velocity = transform.right * velocity;
		GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
	}
	void OnCollisionEnter2D (Collision2D coll) {
		if (!coll.collider.name.Contains("RaceCar")) {
			timeLeftBraking = 1.0f;
		}
	}
	
}
