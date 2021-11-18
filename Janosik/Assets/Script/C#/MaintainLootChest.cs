using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.ZiomakiStudios.Janosik{
    public class MaintainLootChest : MonoBehaviour{
        public int maxAmnt;
        [SerializeField] private int currAmnt;
        public void stealGold(){
            currAmnt -= 1;
        }
        public int getCurrGold(){
            return currAmnt;
        }
        public void replenighGold(){
            currAmnt = maxAmnt;
        }
        // Start is called before the first frame update
        void Start(){
            currAmnt = maxAmnt;
        }

    }
}
