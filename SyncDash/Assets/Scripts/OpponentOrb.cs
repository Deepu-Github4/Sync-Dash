using UnityEngine;

public class OpponentOrb : MonoBehaviour
{
    public int scoreValue = 1;

    void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Opponent")
        {
            ScoreManager.instance.OpponentAddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
