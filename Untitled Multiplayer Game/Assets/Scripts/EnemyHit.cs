using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHit : NetworkBehaviour
{
    public float damageAmount;
    public GameObject enemy;
    public EnemyHealth enHealth;
    public float deathAmount;

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Human"))
        {
            UIPlayerHealth health = collision.gameObject.GetComponentInChildren<UIPlayerHealth>();

            if (health != null && enHealth != null)
            {
                health.LessHealth(damageAmount);
                enHealth.Kamikazze(deathAmount);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("Human"))
        {
            UIPlayerHealth health = collision.gameObject.GetComponentInChildren<UIPlayerHealth>();

            health = collision.gameObject.GetComponent<UIPlayerHealth>();

            if (health != null && enHealth != null)
            {
                health.LessHealth(damageAmount);
                enHealth.Kamikazze(deathAmount);
            }
        }
    }

}
