using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.ZiomakiStudios.Janosik{
    public class GunCOntroller : MonoBehaviour{
        #region Private Serialzied Fields
        [SerializeField] private float gunDamage, weaponRange, fireRate, hitForce, nextFire;
        [Tooltip("How far down the controller trigger needs to be presed in order to trigger the gun. [0,1]")]
        [SerializeField] private float triggerActivation;
        [SerializeField] private Transform muzzleTransform;
        [SerializeField] private AudioSource muzzleSoundSource;
        [SerializeField] private Camera playerCam;  
        [Tooltip("Initial Velocity of bullet leaving barrel.")] [SerializeField] private float initVelocity;
        [SerializeField] private ParticleSystem muzzleFlashPartSys;
        #endregion
        private RaycastHit hit;
        private Vector3 rayOrigin;
        void Start(){
            muzzleFlashPartSys = GetComponentInChildren<ParticleSystem>();
            muzzleSoundSource = GetComponentInChildren<AudioSource>();
            playerCam = transform.root.gameObject.GetComponentInChildren<Camera>();
            muzzleTransform = transform.Find("MuzzleExit");
        }
        void Update(){
            //Check to see if either mouse or controller is being used for weapon fire and we can fire the gun again
            if((Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1") >= triggerActivation) && Time.time > nextFire){
                nextFire = Time.time + fireRate;
                //PLay appropriate sound and particle effects associated with the guven instantiation.
                muzzleFlashPartSys.Play();
                muzzleSoundSource.Play();
                //Access a bullet instantion in the Object Pool that is not active in the scene, 
                //4 is the index of the correlating to the position of its GameObject[] in the List for the Pooled Objects
                GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(4);
                if(bullet != null){
                    //give bullet appropriate position and rotation so it faces direction the barrel faces
                    bullet.transform.position = muzzleTransform.position;
                    bullet.transform.rotation = Quaternion.identity;
                    //Makes sure that this bullet pooled object won't be attempted to be used for a different "instantion"
                    bullet.SetActive(true);
                    //Using bullets rigidbody property to push it away from the barrel in the direction the barrel's facing
                    bullet.GetComponent<Rigidbody>().AddForce(initVelocity*playerCam.transform.forward.normalized);
                }
                bullet = null;
                ///<summary>
                ///Fires raycast through center of camera's viewport into world space
                ///If this ray casted at the same range a bullet from the gun would travels hits an object
                /// the appropriate actions are taken place
                /// If said condition above is true and the players has fired the gun consider it a hit and
                /// fire off appropriate action 
                ///</summary>
<<<<<<< HEAD
                rayOrigin = muzzleTransform.position;
                //rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));
=======
                rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));
                //rayOrigin = muzzleTransform.position;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> d377d19099580dd19fbd61839a4645cdb64fdb8d
>>>>>>> Stashed changes
=======
>>>>>>> d377d19099580dd19fbd61839a4645cdb64fdb8d
>>>>>>> Stashed changes
                Debug.DrawRay(rayOrigin, playerCam.transform.forward.normalized*weaponRange, Color.red);
                if(Physics.Raycast(rayOrigin, playerCam.transform.forward.normalized, out hit, weaponRange)){
                    DamageController targetDmgCont = hit.transform.GetComponent<DamageController>();
                    //When the enemy is hit by the bullet we are gonna take away health
                    if(targetDmgCont!=null)
                        targetDmgCont.TakeDamage(gunDamage, hit, muzzleTransform.position);
                    //Also we are gonna push the person back alittle for a flinching effect
                    if(hit.rigidbody != null)
                        hit.rigidbody.AddForce(-hit.normal*hitForce);
                }
            }
        }
    }
}
