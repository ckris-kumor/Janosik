using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour{
    [SerializeField] private Transform carriageSpawn, banditSpawn;
    [SerializeField] private GameObject Map;

    // Start is called before the first frame update
    void Start(){
        Map = GameObject.FindGameObjectWithTag("Map");
        carriageSpawn = Map.transform.Find("CarriageSpawn");
        banditSpawn = Map.transform.Find("BanditSpawn");
        GameObject carriage = ObjectPool.SharedInstance.GetPooledObject(3);
        if(carriage!=null){
            carriage.transform.position = carriageSpawn.position;
            carriage.transform.rotation = carriageSpawn.rotation;
            carriage.SetActive(true);
        }
        carriage = null;
        GameObject player = ObjectPool.SharedInstance.GetPooledObject(2);
        if(player != null){
            player.transform.position = new Vector3(carriageSpawn.position.x + Random.Range(-15.0f, 15.0f),  carriageSpawn.position.y, carriageSpawn.position.z + Random.Range(-15.0f, 15.0f));
            player.transform.rotation = carriageSpawn.rotation;
            player.SetActive(true);
        }
        player = null;
        GameObject[] bandits = ObjectPool.SharedInstance.GetPooledObjects(1);
        foreach(GameObject bandit in bandits){
            bandit.transform.position = new Vector3(banditSpawn.position.x + Random.Range(-50.0f, 55.0f), banditSpawn.position.y, banditSpawn.position.z + Random.Range(-50.0f, 55.0f));
            bandit.transform.rotation = banditSpawn.rotation;
            bandit.SetActive(true);
        }
        bandits = null;
    }

}
