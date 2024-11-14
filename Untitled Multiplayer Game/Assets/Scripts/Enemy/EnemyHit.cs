using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHit : NetworkBehaviour
{
    public float damageAmount; //this is how much damage enemies deal to players

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Human"))
        {
            UIPlayerHealth health = collision.gameObject.GetComponentInChildren<UIPlayerHealth>(); //get the compoment from the children of the game object 
            PlayerHurt hurt = collision.gameObject.GetComponent<PlayerHurt>(); //get the compoment from the game object

            if (health != null)
            {
                health.LessHealth(damageAmount); //reduce player health

                if (hurt != null)
                {
                    hurt.SetHasTaken(true); //this is to tell another script that it can destory the enemy game object
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Human"))
        {
            UIPlayerHealth health = collision.gameObject.GetComponentInChildren<UIPlayerHealth>();

            health = collision.gameObject.GetComponent<UIPlayerHealth>(); //get the compoment from the children of the game object 
            PlayerHurt hurt = collision.gameObject.GetComponent<PlayerHurt>(); //get the compoment from the game object

            if (health != null)
            {
                health.LessHealth(damageAmount); //reduce player health

                if (hurt != null)
                {
                    hurt.SetHasTaken(true); //this is to tell another script that it can destory the enemy game object
                }
            }
        }
    }

}
