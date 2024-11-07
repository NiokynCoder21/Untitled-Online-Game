using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public PlayerHealth health;
    public float damageAmount;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            if (health != null)
            {
                health.LessHealth(damageAmount);
                print("less health");
            }
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            if (health != null)
            {
                health.LessHealth(damageAmount);
                print("less health");
            }
        }
    }
}
