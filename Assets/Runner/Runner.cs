using UnityEngine;

public class Runner : MonoBehaviour {

	public static float distanceTraveled;
	
	public float acceleration;
	public Vector3 jumpVelocity;
	public float maxSpeed;

	private bool touchingPlatform;
	private bool crouching;

	private Camera mainCam;

	private float timer;
	private Vector3 tempScale;
	private Vector3 tempPos;
	private GameManager manager;

	void Start()
	{
		mainCam = GameObject.Find ("Main Camera").camera;
		manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		crouching = false;
		tempScale = transform.localScale;
		maxSpeed = 12f;
	}


	void Update () 
	{
		mainCam.transform.position = new Vector3 (transform.position.x + 6f, mainCam.transform.position.y, mainCam.transform.position.z); //Track Camera

		timer += Time.deltaTime;

		if(touchingPlatform && Input.GetButtonDown("Jump"))
		{
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
			touchingPlatform = false;
		}
		if (touchingPlatform && Input.GetButton ("Crouch")) 
		{
			crouching = true;
		}
		if (Input.GetButtonUp ("Crouch")) 
		{
			crouching = false;
			if (touchingPlatform)
			{
				tempPos = transform.position;
				tempPos.y += 0.5f;
				transform.position = tempPos;
			}

		}

		if (crouching) 
		{
			if (touchingPlatform) 
			{
				tempScale.y = Mathf.Lerp (1.0f, 0.5f, Time.time * 2);
			}
		} 
		else 
		{
			tempScale.y = Mathf.Lerp (0.5f, 1.0f, Time.time);
		}
		transform.localScale = tempScale;
		distanceTraveled = transform.localPosition.x;

	}

	void FixedUpdate () 
	{
		if (timer >= 15f) 
		{
			timer = 0f;
			maxSpeed += 0.5f;
		}
		if(rigidbody.velocity.x <= maxSpeed)
		{
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		}

		if (!touchingPlatform)
			rigidbody.AddForce (((-acceleration/4f)*3f), 0f, 0f, ForceMode.Acceleration);
		ScoreManager.score = (int)transform.position.x;
		SpeedManager.speed = rigidbody.velocity.x;
	}

	void OnCollisionStay () 
	{
		touchingPlatform = true;
	}

	void OnCollisionEnter (Collision other) 
	{
		if (other.transform.tag == "Obstacle") 
		{
			manager.GameOver();
			Destroy(gameObject);
		}
		else
			touchingPlatform = true;
	}
	void OnCollisionExit () 
	{
		touchingPlatform = false;
	}
}