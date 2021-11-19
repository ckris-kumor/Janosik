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
                itemToDrop.AddComponent<Rigidbody>().useGravity = true;
                itemToDrop.AddComponent<BoxCollider>();
                itemToDrop = null;
            }
        }
    }
}
