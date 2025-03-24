using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static float globalSpeed = 5f;
    public float speedIncreaseRate = 0.1f;

    void Update()
    {
        globalSpeed += speedIncreaseRate * Time.deltaTime;
    }
}
