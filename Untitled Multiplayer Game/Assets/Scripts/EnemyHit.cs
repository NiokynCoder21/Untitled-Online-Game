using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHit : NetworkBehaviour
{
    public UIPlayerHealth health;
    public float damageAmount;
    public GameObject enemy;
    public EnemyHealth enHealth;
    public float deathAmount;

    [Server]
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}, isServer: {isServer}");

        if (collision.gameObject.CompareTag("Human"))
        {
            if (!isServer) return;

            health = collision.gameObject.GetComponent<UIPlayerHealth>();

            if (health != null && enHealth != null)
            {
                health.LessHealth(damageAmount);
                enHealth.Kamikazze(deathAmount);
            }
        }
    }

    [Server]
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}, isServer: {isServer}");

        if (collision.gameObject.CompareTag("Human"))
        {
            if (!isServer) return;

            health = collision.gameObject.GetComponent<UIPlayerHealth>();

            if (health != null && enHealth != null)
            {
                health.LessHealth(damageAmount);
                enHealth.Kamikazze(deathAmount);
            }
        }
    }

}
