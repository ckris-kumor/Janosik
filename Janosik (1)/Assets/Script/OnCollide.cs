using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollide : MonoBehaviour{
    public void OnCollisionEnter(Collision other){
        Destroy(gameObject);

    }
}
