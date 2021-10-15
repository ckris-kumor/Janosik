using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//following Unity tutorial on object pooling https://learn.unity.com/tutorial/introduction-to-object-pooling#5ff8d015edbc2a002063971d
//modifications made to make it so the list of pool objects is seperated by the type of gameobject.

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject[]> pooledObjects;
    public GameObject[] objectsToPool;
    //Populate int[] such that index corellates to the index of the objectsToPool[]
    public int[] amountToPoolEachObject;
    void Awake(){
        SharedInstance = this;
        pooledObjects = new List<GameObject[]>();
        for (int i = 0; i < objectsToPool.Length; i++){
            GameObject[] tmp = new GameObject[amountToPoolEachObject[i]];
            for(int j  = 0; j < amountToPoolEachObject[i];j++){
                tmp[j] = Instantiate(objectsToPool[i]);
                tmp[j].SetActive(false);
            }
            pooledObjects.Add(tmp);
            tmp = null;
        }
    }
    public GameObject GetPooledObject(int objType){
        for(int i = 0; i < amountToPoolEachObject[i]; i++){
            if(!pooledObjects[objType-1][i].activeInHierarchy)
                return pooledObjects[objType-1][i];
        }
        return null;
    }
    public GameObject GetActiveObject(int objType){
        for(int i = 0; i < amountToPoolEachObject[i]; i++){
            if(pooledObjects[objType-1][i].activeInHierarchy)
                return pooledObjects[objType-1][i];
        }
        return null;
    }
    public GameObject[] GetPooledObjects(int objType){
        return pooledObjects[objType-1];
    }
    public List<GameObject> GetActiveObjects(int objType){
        List<GameObject> tmp  = new List<GameObject>();
        for(int i = 0; i < amountToPoolEachObject[i]; i++){
            if(pooledObjects[objType-1][i].activeInHierarchy)
                tmp.Add(pooledObjects[objType-1][i]);
        }
         return tmp;
    }

}
