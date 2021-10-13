using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCOntroller : MonoBehaviour{
    [SerializeField] private float gunDamage, weaponRange, fireRate, hitForce, nextFire;
    [Tooltip("How far down the controller trigger needs to be presed in order to trigger the gun. [0,1]")]
    [SerializeField] private float triggerActivation;
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private AudioSource muzzleSoundSource;
    [SerializeField] private Camera playerCam;  
    [Tooltip("Initial Velocity of bullet leaving barrel.")] [SerializeField] private float initVelocity;
    [SerializeField] private ParticleSystem muzzleFlashPartSys;
    private RaycastHit hit;
    private Vector3 rayOrigin;
    void Start(){
        muzzleFlashPartSys = GetComponentInChildren<ParticleSystem>();
        muzzleSoundSource = GetComponentInChildren<AudioSource>();
        playerCam = transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.gameObject.GetComponentInChildren<Camera>();
        muzzleTransform = transform.Find("MuzzleExit");
    }
    void Update(){
        if((Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1") >= triggerActivation) && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            muzzleFlashPartSys.Play();
            muzzleSoundSource.Play();
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(4);
            if(bullet != null){
                bullet.transform.position = muzzleTransform.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody>().AddForce(initVelocity*playerCam.transform.forward.normalized);
            }
            bullet = null;
            rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));
            Debug.DrawRay(rayOrigin, playerCam.transform.forward.normalized*weaponRange, Color.red);
            if(Physics.Raycast(rayOrigin, playerCam.transform.forward.normalized, out hit, weaponRange)){
                BanditOnTrigger banditHitBox = hit.transform.GetComponent<BanditOnTrigger>();
                if(banditHitBox!=null)
                    banditHitBox.HitByBullet(gunDamage, hit.point);
                if(hit.rigidbody != null)
                    hit.rigidbody.AddForce(-hit.normal*hitForce);
            }
        }
    }
}
