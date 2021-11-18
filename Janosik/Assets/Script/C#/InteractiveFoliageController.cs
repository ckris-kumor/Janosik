using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    namespace Com.ZiomakiStudios.Janosik{
    public class InteractiveFoliageController : MonoBehaviour
    {
        #region Private Members
        [SerializeField] private Material[] materials; 
    
        private Vector3 pos;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("writeMaterial");
        }

        IEnumerator writeMaterial(){
            while(true){
                foreach(Material curMat in materials)
                    curMat.SetVector("_playerPos", gameObject.transform.position);
                yield return null;
            }
        }
    }
}
