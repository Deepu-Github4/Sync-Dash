using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float resetPositionZ = -10f; 
    public float spawnPositionZ = 10f; 

    void Update()
    {
        transform.position += Vector3.back * SpeedManager.globalSpeed * Time.deltaTime;
        if (transform.position.z < resetPositionZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        }
    }
}
