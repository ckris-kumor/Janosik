using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.ZiomakiStudios.Janosik{
    public static class DropItem{
        public static void DropingItem(GameObject holder, string objectLoc){
            GameObject itemToDrop = holder.transform.Find(objectLoc).gameObject;
            if(itemToDrop!=null){
                //By setting parent to null the dropped intem is know a gameObject whose parent is the scene
                itemToDrop.transform.parent = null;
                Rigidbody itemRB = itemToDrop.AddComponent<Rigidbody>();
                itemRB.useGravity = true;
                itemRB.AddForce(itemToDrop.transform.up.normalized*2.5f, ForceMode.Impulse);
                itemToDrop.AddComponent<BoxCollider>();
                itemToDrop = null;
            }
        }
    }
}
