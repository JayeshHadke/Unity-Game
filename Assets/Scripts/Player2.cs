using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
	public float moveForce = 10f;
	public float jumpForce = 11f;
	private float movementX;

	private Rigidbody2D rb;
	private SpriteRenderer sr;

	private Animator anim;
	private string WALK_ANIMATION = "Walk";
	
	private bool isGrounded = true;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		
	}

    // Update is called once per frame
    void Update() 
    {
		PlayerMoveKeyboard();
		AnimatePlayer();
		PlayerJump();
		
	}

	void PlayerMoveKeyboard()
	{
		movementX = Input.GetAxisRaw("Horizontal");
		transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
	}

	void AnimatePlayer()
	{
		if (movementX > 0)
		{
			sr.flipX = false;
			anim.SetBool(WALK_ANIMATION, true);
		}
		else if (movementX < 0)
		{
			sr.flipX = true;
			anim.SetBool(WALK_ANIMATION, true);
		}
		else
		{
			anim.SetBool(WALK_ANIMATION, false);
		}
	}

	private void FixedUpdate()
	{
	}

	void PlayerJump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			isGrounded = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}
}
