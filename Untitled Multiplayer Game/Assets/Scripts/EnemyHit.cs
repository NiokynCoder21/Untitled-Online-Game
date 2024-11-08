using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHit : NetworkBehaviour
{
    public UIPlayerHealth health;
    public float damageAmount;
    public GameObject enemy;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            health = collision.gameObject.GetComponent<UIPlayerHealth>();

            if (health != null)
            {
                health.LessHealth(damageAmount);
                NetworkServer.Destroy(enemy);

            }
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            health = collision.gameObject.GetComponent<UIPlayerHealth>();

            if (health != null)
            {
                print("less health");
                health.LessHealth(damageAmount);
                NetworkServer.Destroy(enemy);
            }
        }
    }
}
