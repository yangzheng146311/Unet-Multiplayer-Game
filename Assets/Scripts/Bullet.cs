using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
        GameObject hit = col.gameObject;
        Enemy health = hit.GetComponent<Enemy>();

        if (health != null)
        {
            health.TakeDamage(10);
        }
        Destroy(this.gameObject);
    }

}
