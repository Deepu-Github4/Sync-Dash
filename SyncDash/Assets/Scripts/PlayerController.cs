using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float jumpForce = 7f;
    private Rigidbody rb;
    public bool gameStart = false;
    public static System.Action<bool> OnPlayerJump;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameStart)
        {
            if (IsJumpInput() && IsGrounded())
            {
                Jump();
                OnPlayerJump?.Invoke(true);
            }
        }
    }

    bool IsJumpInput()
    {
        return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            MenuScript.instance.GameOver();
        }
    }
}
