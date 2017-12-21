using UnityEngine;

public class MovementController : MonoBehaviour {

    public float moveSpeed = 1f;
    public float jumpPower = 5f;
    public bool onGround = false;

    private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Jump") > 0f && onGround)
        {
            Jump();
        }
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 movement = Vector3.right * horizontalAxis * moveSpeed * Time.fixedDeltaTime;
        //myRigidbody.MovePosition(transform.position + movement);
    }

    private void Jump()
    {
        onGround = false;
        Vector2 jumpForce = Vector2.up * jumpPower;
        myRigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (myRigidbody.velocity.y == 0f) onGround = true;
    }
}
