using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public GameObject magPickUpText;
    public Weapon weapon;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(true);

            if (weapon != null)
            {
                weapon.SetCanPickUp(true);

                if (weapon.hasPickedUp == true)
                {
                    weapon.SetCanPickUp(false);
                    magPickUpText.gameObject.SetActive(false);
                    weapon.hasPickedUp = false;
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(true);

            if (weapon != null)
            {
                weapon.SetCanPickUp(true);

                if (weapon.hasPickedUp == true)
                {
                    weapon.SetCanPickUp(false);
                    magPickUpText.gameObject.SetActive(false);
                    weapon.hasPickedUp = false;
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(false);

            if (weapon != null)
            {
                weapon.SetCanPickUp(false);
            }

            if (weapon.hasPickedUp == true)
            {
                weapon.SetCanPickUp(false);
                magPickUpText.gameObject.SetActive(false);
                weapon.hasPickedUp = false;
                Destroy(other.gameObject);
            }
        }
    }
}
