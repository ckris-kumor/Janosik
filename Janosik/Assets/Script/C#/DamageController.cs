using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.ZiomakiStudios.Janosik{
    public class DamageController : MonoBehaviour{
        #region Private Fields
        [SerializeField] private PlayerInfo m_playerInfo;
        [SerializeField] private PlayerCont m_playerCont;
        [SerializeField] private PlayerLook m_playerLook;
        [SerializeField] private Animator m_Animator;
        [SerializeField] private CharacterController m_characterCont;
    
        [Tooltip("The location of the player's head in the player's gameObject hierarchy")]
        [SerializeField] private string headLoc;
        private Transform headTransform;
        [Tooltip("The minimum dist an attacks impact is from the enter of the head to be considered headshot")]
        [SerializeField] private float minDist;
        private int isDyingHash, finAtkHHash, finAtkVHash, isHeadShotHash;
        #endregion

        void Start(){
            m_playerInfo = GetComponent<PlayerInfo>();
            m_playerCont = GetComponent<PlayerCont>();
            m_playerLook = GetComponent<PlayerLook>();
            m_Animator = GetComponent<Animator>();
            m_characterCont = GetComponent<CharacterController>();
            headTransform = gameObject.transform.Find(headLoc);
            isDyingHash = Animator.StringToHash("isDying");
            finAtkHHash = Animator.StringToHash("finalBlowHorizontal");
            finAtkVHash = Animator.StringToHash("finalBlowVertical");
            isHeadShotHash = Animator.StringToHash("isHeadSHot");
        }
        IEnumerator triggerDeath(bool isHeadShot, Vector3 atkDir){
            m_playerInfo.Sethp(0);
            //"Drop" any gold they have, tbd how gold is dropped
            m_playerInfo.SethasGold(m_playerInfo.GethasGold()?(false):false);
            //Prevent player from moving when triggering death animation
            m_playerCont.enabled = false;
            m_playerLook.enabled = false;
            m_characterCont.enabled = false;
            //Trigger death state in player's animation controller
            m_Animator.SetBool(isHeadShotHash, isHeadShot);
            m_Animator.SetFloat(finAtkHHash, atkDir.x);
            m_Animator.SetFloat(finAtkVHash, atkDir.z);
            m_Animator.SetTrigger(isDyingHash);
            DropItem.DropingItem(gameObject, m_playerCont.gunLoc);
            Debug.Log($"Headshot:{isHeadShot}, normal direction (x, z) : ({atkDir.x}, {atkDir.z}).");
            yield return new WaitForSeconds(5.0f);
            gameObject.SetActive(false);
        }

        public void TakeDamage(float weaponDamage, RaycastHit hit, Vector3 atkInitPos){
            ///<summary>
            /// When the player is hit by a damaging collision determine damage based on properties of impact
            /// For now check to see if the impact is such distance from the center of the head,
            /// if it lies within or is minDist, consider the impact a headshot
            ///</summary>
            float distFromHead = Vector3.Distance(headTransform.position, hit.point);
            bool isHeadShot = distFromHead<=minDist;
            Debug.Log($"The bullet is {distFromHead} from the head.");
            float damage = isHeadShot?weaponDamage*2.0f:weaponDamage;
            //If the player dies from this hit
            if ((m_playerInfo.Gethp() - damage) <= 0)
                StartCoroutine(triggerDeath(isHeadShot, (atkInitPos-hit.point).normalized));
            //If this bullet does not kill use then apply appropriate damage to bandits health
            else
                m_playerInfo.Sethp(m_playerInfo.Gethp() - damage);
        }
    }
}