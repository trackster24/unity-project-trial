using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
