using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public GameObject magPickUpText;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(false);
        }
    }
}
