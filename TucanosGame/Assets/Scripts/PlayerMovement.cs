using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	//Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 500f;          // The length of the ray from the camera into the scene.
	bool disabled;

	void Awake ()
	{
		disabled = false;
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Floor");
		
		// Set up references.
		//anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	
	void FixedUpdate ()
	{
		if (!disabled) {
			// Store the input axes.
			float h = Input.GetAxisRaw ("Horizontal");
			float v = Input.GetAxisRaw ("Vertical");
		
			// Move the player around the scene.
			Move (h, v);
		
			// Turn the player to face the mouse cursor.
			Turning (h, v);
		}
	}
	
	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}
	
	void Turning (float h, float v)
	{
		if (h != 0 || v != 0) {
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = new Vector3 (-h, 0f, -v);

			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			
			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotation);
		}
	}

	public void disable(){
		disabled = true;
	}

	public bool isDisabled(){
		return disabled;
	}
}