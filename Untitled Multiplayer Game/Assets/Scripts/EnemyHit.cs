using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHit : NetworkBehaviour
{
    public float damageAmount;
    public GameObject enemy;
    public float deathAmount;


    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Human"))
        {
            UIPlayerHealth health = collision.gameObject.GetComponentInChildren<UIPlayerHealth>();
            PlayerHurt hurt = collision.gameObject.GetComponent<PlayerHurt>();

            if (health != null)
            {
                health.LessHealth(damageAmount);
                print("enemy dead");

                if (hurt != null)
                {
                    hurt.SetHasTaken(true);
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Human"))
        {
            UIPlayerHealth health = collision.gameObject.GetComponentInChildren<UIPlayerHealth>();

            health = collision.gameObject.GetComponent<UIPlayerHealth>();
            PlayerHurt hurt = collision.gameObject.GetComponent<PlayerHurt>();

            if (health != null)
            {
                health.LessHealth(damageAmount);
                print("enemy dead");

                if (hurt != null)
                {
                    hurt.SetHasTaken(true);
                }
            }
        }
    }

}
