using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletRB;

    void Start(){
        bulletRB = gameObject.GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision col){
        Destroy(gameObject);
    }
}
