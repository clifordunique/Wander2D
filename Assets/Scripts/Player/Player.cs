using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public Animator animator;

	public ParticleSystem walkParticles;

	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;

	public float FlashingTime = .6f;
    public float TimeInterval = .1f;

	bool isGrounded = false;

	Vector3 respawnPoint;
	float respawnHeight;

	float xSize;
	float pxSize;
	float pxPosition;

	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	public float moveSpeed = 1.5f;

	public float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;
	bool isDead = false;
	public float fadeInSpeed;

	Controller2D controller;
	Transform prompt;

	void Start() {
		prompt = transform.Find("Prompt");
		pxSize = prompt.localScale.x;
		pxPosition = prompt.localPosition.x;
		xSize = transform.localScale.x;
		controller = GetComponent<Controller2D> ();
		respawnPoint = transform.position;

		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		// print ("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
	}

	void FixedUpdate()
	{
		HandleLayers();
	}

	void Update() {
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if(isDead) {
			Color tempColor = gameObject.GetComponent<SpriteRenderer>().color;
			tempColor.a += fadeInSpeed;
			if(tempColor.a >= 1)
				isDead = false;
			gameObject.GetComponent<SpriteRenderer>().color = tempColor;
		}

		if(!isGrounded) {
			walkParticles.Stop();
		} else {
			animator.SetLayerWeight(1, 0);
			animator.ResetTrigger("Jump");
			animator.SetBool("Falling", false);
		}

		if(Input.GetAxisRaw("Horizontal") != 0) {
			animator.SetInteger("Walk", 1);

			if(Input.GetAxisRaw("Horizontal") > 0) {
				transform.localScale = new Vector3(xSize, transform.localScale.y, transform.localScale.z);
				prompt.localPosition = new Vector3(pxPosition, prompt.localPosition.y, prompt.localPosition.z);
				prompt.localScale = new Vector3(pxSize, prompt.localScale.y, prompt.localScale.z);
			}
			else if(Input.GetAxisRaw("Horizontal") < 0) {
				transform.localScale = new Vector3(-(xSize), transform.localScale.y, transform.localScale.z);
				prompt.localPosition = new Vector3(-(pxPosition), prompt.localPosition.y, prompt.localPosition.z);
				prompt.localScale = new Vector3(-(pxSize), prompt.localScale.y, prompt.localScale.z);
			}

			if(isGrounded)
				walkParticles.Play();
		}
		else {
			animator.SetInteger("Walk", 0);
			walkParticles.Stop();
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

		if (Input.GetButtonDown ("Jump")) {
			animator.SetTrigger("Jump");
			if (controller.collisions.below) {
				velocity.y = maxJumpVelocity;
			}
		}

		if (velocity.y < 0) {
			animator.SetBool("Falling", true);
		}

		if (Input.GetButtonUp ("Jump")) {
			if (velocity.y > minJumpVelocity) {
				velocity.y = minJumpVelocity;
			}
		}

	
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
	}

	IEnumerator Flash(float time, float intervalTime)
	{
		//this counts up time until the float set in FlashingTime
		float elapsedTime = 0f;
		//This repeats our coroutine until the FlashingTime is elapsed
		while(elapsedTime < time ){
			//This gets an array with all the renderers in our gameobject's children
			Renderer[] RendererArray = GetComponentsInChildren<Renderer>();
			//this turns off all the Renderers
			foreach(Renderer r in RendererArray)
			r.enabled = false;
			//then add time to elapsedtime
			elapsedTime += Time.deltaTime;
			//then wait for the Timeinterval set
			yield return new WaitForSeconds(intervalTime);
			//then turn them all back on
			foreach(Renderer r in RendererArray)
			r.enabled = true;
			elapsedTime += Time.deltaTime;
			//then wait for another interval of time
			yield return new WaitForSeconds(intervalTime);
		}
	}

	void HandleLayers() {
		if(!isGrounded)
			animator.SetLayerWeight(1, 1);
		else
			animator.SetLayerWeight(1, 0);
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Through")) {
			isGrounded = true;
			animator.ResetTrigger("Jump");
			animator.SetBool("Falling", false);
		}

		if(other.gameObject.CompareTag("FallDetector")) {
			transform.position = respawnPoint;
			Color transparent = gameObject.GetComponent<SpriteRenderer>().color;
			transparent.a = 0;
			gameObject.GetComponent<SpriteRenderer>().color = transparent;
			isDead = true;
			// StartCoroutine(Flash(FlashingTime, TimeInterval));
		}

		if(other.gameObject.CompareTag("Checkpoint")) {
			respawnPoint = other.transform.position;
			respawnHeight = other.gameObject.GetComponent<Checkpoint>().getRespawnHeight();
			respawnPoint.y = respawnPoint.y + respawnHeight;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "Platform" || other.gameObject.tag == "Through") {
			isGrounded = false;
		}
	}

	public float getGravity() {
		return gravity;
	}
}
