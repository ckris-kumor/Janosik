using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void DestroyBullet(){
        //By making the object not active in the scene we make it avalable for future pooling
        gameObject.SetActive(false);
    }
    //If player fired shot without hitting something then make sure bullet is "destroyed"
    void OnEnable(){
        Invoke("DestroyBullet", 2.0f);
    }

}
