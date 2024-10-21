using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    public float damage = 50f; //this is the amount of damage the gun deals 
    public float range = 100f; //this is the range that the gun raycast shoots 

    public ParticleSystem muzzleflash; 
    public float impactForce = 30f; //this is how much forced is applied to the the rigidbody hit

    public int maxAmmo = 6; //this will store the max ammo
    public int currentAmmo; //this will store the current ammo

    public float reloadTime = 2f; //the amount of time it takes for the gun to reload

    public AudioClip gunSound; //the sound that plays when the gun shoots
    public AudioClip reloadSound; // the sound that plays when the gun reloads
    public AudioClip emptyGunSound; //the sound that plays when the gun has no bullets

    public float reloadAmount; // this will store the current reload ammount
    public float maxReload = 2f; //what is the max amounts of reloads the gun has

    public TextMeshProUGUI currentAmmoText; //text that shows current ammo amount
    public TextMeshProUGUI maxAmmoText; //text that shows the max ammo amount

    public bool isReloading = false; //bool to check if player is reloading

    public float distance = 50f; //how player the raycast shoots for interaction
    public GameObject ammo; //to assign in scence 

    public float fireRateInSec = 3f; //how long the player has to wait between shots

    public Camera cam; //to assign camera in scence 
    public bool isShooting = false; //bool to check if player is shooting
    public TextMeshProUGUI magAmount; //textmeshpro that shows the magamount

    private void Start()
    {
        AudioSource audio = GetComponent<AudioSource>(); //get component audio source store as audio
        currentAmmo = maxAmmo; //set current ammo to max ammo
        reloadAmount = maxReload; //set reload amount to max relaod 
        UpdateAmmoUI(); //update the ammo ui
        Text interactableText = GetComponent<Text>(); //get component text and store as interactable text
        TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>(); //get component textmeshprogui and store as new text
    }

    private void Update()
    {
        Interaction();

        if (Input.GetButtonDown("Fire1") && !isReloading && !isShooting) //if fire button pressed(left mouse button), isreloading is false and isshooting is false
        {

            if (currentAmmo > 0) //if current ammo is greater than zero
            {
                AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
                audio.clip = gunSound; //make the audio clip be gunsound 
                audio.Play(); //play the audio clip gun sound
                Shoot(); //call shoot method
                StartCoroutine(FireRate()); //start courtine that simulates fire rate 
                print("POLAYER SGOOTING");
            }

            else if (currentAmmo <= 0) //if current ammo is less than or equal to zero
            {
                AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
                audio.clip = emptyGunSound; //make the audio clip be emptygunsound
                audio.Play(); //play the audio clip be emptygunsound
            }
        }

        

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && reloadAmount > 0) //if R is pressed , current ammo is less than max ammo and reload amount is more than zero
        {
            StartCoroutine(Reload()); //start courtine to simulate player reloading
            reloadAmount--; //each time pressed reload amount reduces by 1
            UpdateAmmoUI(); //update ammo ui
        }

    }

    void Interaction()
    {
        RaycastHit hit; //this will store what the raycast hit

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance)) //shoots a raycast and checks if it hits 
        {
            string hitTag = hit.collider.tag; //if hit something with tag store as hittag

            if(hitTag == "Ammo") //check if hittag has the tag ammo
            {
                if (Input.GetKeyDown(KeyCode.I)) //if player presses I
                {
                    reloadAmount++; //increase the reloadamount the player has
                    Destroy(ammo); //destroy the ammo gameobject
                    UpdateAmmoUI(); //update ammo ui
                }
            }


            if (hitTag == "win")
            {
                SceneManager.LoadScene("Winner", LoadSceneMode.Single);
            }
        }
    }

    void Shoot()
    {
        muzzleflash.Play(); //play muzzle flash particle system

        //RaycastHit hit;

            currentAmmo--;
            UpdateAmmoUI();

       /* if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit ,range)) //ray cast from camera to a specified range and store what it hit in hit
        {
            BadGuy badguy = hit.transform.GetComponent<BadGuy>(); //get component badguy from hit transform and store as badguy

            if (badguy != null) //does the object have the badhuy script 
            {
                badguy.TakeDamage(damage); //if yes pass damagae to it
            }
        }*/
    }

    //Brackeys. (2017, April 19). Shooting with Raycasts - Unity tutorial. YouTube. https://youtu.be/THnivyG0Mvo?si=BK_QFrOeuHZNeGAD 

    private IEnumerator FireRate() //controlls the time between shots to simulate a fire rate
    {
        isShooting = true; //player is shooting 
        yield return new WaitForSeconds(fireRateInSec); //pause for specified secs
        isShooting = false; //player is not shooting
    }


    private IEnumerator Reload() //controlls recoil
    {
        isReloading = true; //player is reloading
        AudioSource audio = GetComponent<AudioSource>(); //get component audiosource and store as audio
        audio.clip = reloadSound; //make the audio clip be reloadSound
        audio.Play(); //make the audio clip play

        yield return new WaitForSeconds(reloadTime); //pause for specified secs

        currentAmmo = maxAmmo; //set current ammo to max ammo
        isReloading = false; //player is not reloading
        UpdateAmmoUI(); //update ammo ui
    }

    void UpdateAmmoUI()
    {
        currentAmmoText.text = "" + currentAmmo; //display current ammo onto the screen
        maxAmmoText.text = "" + maxAmmo; //display max ammo onto the screen 
        magAmount.text = "" + reloadAmount; //display the reload amount on screen
    }
}
