using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCOntroller : MonoBehaviour{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private AudioSource muzzleSoundSource;
    [SerializeField] private Camera playerCam;
    [Tooltip("Initial Velocity of bullet leaving barrel.")] [SerializeField] private float initVelocity;
    [SerializeField] private ParticleSystem muzzleFlashPartSys;
    private GameObject spawnedBullet;
    void Start(){
        muzzleFlashPartSys = gameObject.GetComponentInChildren<ParticleSystem>();
        muzzleSoundSource = gameObject.GetComponentInChildren<AudioSource>();
    }
    void Update(){
        //gameObject.transform.LookAt(playerCam.transform, -gameObject.transform.rotation.eulerAngles);
        if(Input.GetButtonDown("Fire1")){
            muzzleFlashPartSys.Play();
            muzzleSoundSource.Play();
            spawnedBullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody>().AddRelativeForce(initVelocity*playerCam.transform.forward);
            Destroy(spawnedBullet, 5.00f);
            spawnedBullet = null;
       
        }
    }
}
