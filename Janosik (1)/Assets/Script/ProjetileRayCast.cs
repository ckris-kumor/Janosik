using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ProjetileRayCast : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject Gun;
    public float speed;
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public Camera rayCamera; 
    public ParticleSystem muzzleParticles;
    private int playerAmmo;
    private int maxAmmo;
    private int magSize;
    private Ray ray; 

    private AtSpawn playerController;

    public void Start(){
        playerController = gameObject.GetComponentInParent<AtSpawn>();
        magSize = 12;
        
    }
     // Update is called once per frame
    public void Update(){
        playerAmmo = playerController.GetCurrAmmo();
        maxAmmo = playerController.GetMaxAmmo();
        rayCamera.transform.forward = playerCamera.transform.forward;
        ray = rayCamera.ScreenPointToRay(Input.mousePosition);
        //Gun.transform.LookAt(rayCamera.transform.forward, Vector3.forward);
        if (Input.GetMouseButtonDown(0) && (playerAmmo > 0)){
            playerController.SetCurrAmmo(playerAmmo - 1);
            muzzleParticles.Play();
            GameObject firedBullet = Instantiate(bullet, bulletSpawnPos.position, Quaternion.identity);
            firedBullet.GetComponent<Rigidbody>().AddRelativeForce(ray.direction * speed);
            Destroy(firedBullet, 3.0f);
        }
        else if (Input.GetKeyDown(KeyCode.R)){
            int diff = magSize - playerAmmo;
            if (diff < maxAmmo){
                playerAmmo = magSize;
                maxAmmo -= diff;
            }
            else if (diff > maxAmmo && maxAmmo != 0){
                playerAmmo += maxAmmo;
                maxAmmo = 0;
            }
            playerController.SetCurrAmmo(playerAmmo);
            playerController.SetMaxAmmo(maxAmmo);
        }
    }
}
