using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.ZiomakiStudios.Janosik{
    public class PlayerInfo : MonoBehaviour{
    //embody player with appropriate attributes
    private int hp;
    public bool hasGold;
    public void Start(){
       this.hp = 100;
       this.hasGold = false;
    }
    public int Gethp(){
        return hp;
    }
    public void Sethp(int newHP){
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
