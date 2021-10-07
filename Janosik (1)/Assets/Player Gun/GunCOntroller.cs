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
        playerCam = gameObject.transform.parent.gameObject.GetComponentInChildren<Camera>();
        muzzleFlashPartSys = gameObject.GetComponentInChildren<ParticleSystem>();
        muzzleSoundSource = gameObject.GetComponentInChildren<AudioSource>();
    }
    void Update(){
        gameObject.transform.up = -playerCam.transform.forward;
        if(Input.GetButtonDown("Fire1")){
            muzzleFlashPartSys.Play();
            muzzleSoundSource.Play();
            spawnedBullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody>().velocity = initVelocity*bulletSpawn.forward;
            Destroy(spawnedBullet, 5.00f);
            spawnedBullet = null;
       
        }
    }
}
