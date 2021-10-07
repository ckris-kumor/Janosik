using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletRB;
    [SerializeField] private GameObject woodenBulletImpact, dirtBulletImpact;

    void Start(){
        
    }
    //WHen the bullet Collies destroy it
    void OnCollisionEnter(Collision col){
        switch (col.transform.tag){
            case("Tree"):
                Instantiate(woodenBulletImpact, col.transform.position, Quaternion.identity);
                break;
            case("Terrain"):
                Instantiate(dirtBulletImpact, col.transform.position, Quaternion.identity);
                break;
        }
        Destroy(gameObject);
    
    }
}
