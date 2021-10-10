using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void DestroyBullet(){
        Destroy(gameObject);
    }
    void Start(){
        Invoke("DestroyBullet", 0.5f);
    }

}
