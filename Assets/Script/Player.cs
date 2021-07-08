using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveForce = 10f;
    private float jumpFroce = 11f;

    private float movemnetX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;
    private bool isGrounded = true;

    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

    }

    private void FixedUpdate()
    {
        
    }

    void PlayerMoveKeyboard()
    {
        movemnetX = Input.GetAxis("Horizontal");

        

        transform.position += new Vector3(movemnetX, 0f, 0f) * Time.deltaTime * moveForce;


    }

    void AnimatePlayer()
    {
        if (movemnetX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movemnetX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpFroce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
		{
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(ENEMY_TAG))
		{
            Destroy(gameObject);
		}
	}
}
