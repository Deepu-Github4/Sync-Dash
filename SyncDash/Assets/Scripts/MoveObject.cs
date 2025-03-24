using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float speedIncreaseRate = 0.1f;

    void Update()
    {
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        moveSpeed += speedIncreaseRate * Time.deltaTime;

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
