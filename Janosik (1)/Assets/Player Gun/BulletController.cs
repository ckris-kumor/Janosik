using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void DestroyBullet(){
        gameObject.SetActive(false);
    }
    void OnEnable(){
        Invoke("DestroyBullet", 2.0f);
    }

}
