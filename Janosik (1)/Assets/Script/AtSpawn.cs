using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AtSpawn : MonoBehaviour{
     int hp, maxAmmo, curAmmo;
    public bool hasGold;
    public void Start(){
       this.hp = 100;
       this.maxAmmo = 20;
       curAmmo = 1;
       this.hasGold = false;
    }
    public int GetCurrAmmo(){
        return this.curAmmo;
    }
    public void SetCurrAmmo(int amount){
        curAmmo = amount;
    }
    public int Gethp(){
        return hp;
    }
    public void Sethp(int newHP){
        this.hp = newHP;
    }
    public int GetMaxAmmo(){
        return this.maxAmmo;
    }
    public void SetMaxAmmo(int amount){
        this.maxAmmo = amount;
    }
    public void SethasGold(bool val){
        this.hasGold = val;
    }
    public bool GethasGold(){
        return this.hasGold;
    }
}
