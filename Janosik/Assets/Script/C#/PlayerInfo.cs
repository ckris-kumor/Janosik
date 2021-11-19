using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.ZiomakiStudios.Janosik{
    public class PlayerInfo : MonoBehaviour{
    //embody player with appropriate attributes
    private float hp;
    public bool hasGold;
    public void Start(){
       this.hp = 100.0f;
       this.hasGold = false;
    }
    public float Gethp(){
        return hp;
    }
    public void Sethp(float newHP){
        this.hp = newHP;
    }
    public void SethasGold(bool val){
        this.hasGold = val;
    }
    public bool GethasGold(){
        return this.hasGold;
    }
    }
}
