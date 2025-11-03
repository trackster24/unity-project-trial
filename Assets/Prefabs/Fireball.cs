using UnityEngine;

public class Fireball : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Destroyable")
        {
            ScoreManager.instance.incrementScore(100);
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
