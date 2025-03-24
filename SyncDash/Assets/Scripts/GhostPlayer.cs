using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GhostPlayer : MonoBehaviour
{
    private Rigidbody rb;
    private Queue<bool> jumpQueue = new Queue<bool>();
    public float lagTime = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerController.OnPlayerJump += StoreJumpAction;
    }

    void OnDestroy()
    {
        PlayerController.OnPlayerJump -= StoreJumpAction;
    }

    void Update()
    {
        if (jumpQueue.Count > 0)
        {
            StartCoroutine(ProcessJump());
        }
    }

    void StoreJumpAction(bool jump)
    {
        StartCoroutine(DelayedJump(jump));
    }

    IEnumerator DelayedJump(bool jump)
    {
        yield return new WaitForSeconds(lagTime);
        jumpQueue.Enqueue(jump);
    }

    IEnumerator ProcessJump()
    {
        if (jumpQueue.Dequeue() && IsGrounded())
        {
            Jump();
        }
        yield return null;
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 10f, rb.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
