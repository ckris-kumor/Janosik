using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.ZiomakiStudios.Janosik{
    public class TriggerEndGame : MonoBehaviour
    {
        [SerializeField] private SphereCollider carriageDetector;
        [SerializeField] private GameObject carriage;
        // Start is called before the first frame update
        void Start(){
            carriageDetector = GetComponent<SphereCollider>();
            carriage = ObjectPool.SharedInstance.GetActiveObject(2);
            
        }

        // Update is called once per frame
        void Update(){
            if(carriageDetector.bounds.Contains(carriage.transform.position))
                SceneManager.LoadScene("Results", LoadSceneMode.Single);
        }
    }
}
