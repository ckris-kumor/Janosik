using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.ZiomakiStudios.Janosik{
    public class UpdateEnemyHealth : MonoBehaviour{
        [SerializeField] private ProgressBar enemyHealthBar;
        // Start is called before the first frame update
        void Start(){
            enemyHealthBar = GetComponent<ProgressBar>();
            gameObject.SetActive(false);
        }

        public void ShowEnemyHealth(string name, float health){
            enemyHealthBar.Title = name;
            enemyHealthBar.UpdateValue(health/100.0f);
        }
    }
}
