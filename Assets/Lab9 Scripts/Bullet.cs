using UnityEngine;


public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<Target>().Hit();
            BulletPool.Instance.ReturnBullet(this.gameObject);
        }        
    }
}