using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameObject particle;
    public int scoreValue = 1; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            ScoreManager.instance.AddScore(scoreValue);
            Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
