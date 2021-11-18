using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.ZiomakiStudios.Janosik{
    public class UpdateHealth : MonoBehaviour
    {
        [SerializeField] private PlayerInfo playerInfo;
        [SerializeField] ProgressBar HPProgressBar;
    
        // Start is called before the first frame update
        public void Start(){
            playerInfo = GetComponentInParent<PlayerInfo>();
            HPProgressBar = GetComponent<ProgressBar>();
            HPProgressBar.UpdateValue((float)(playerInfo.Gethp()/100));
        }
        void Update(){
            HPProgressBar.UpdateValue((float)(playerInfo.Gethp()/100));
        }
    }
}
