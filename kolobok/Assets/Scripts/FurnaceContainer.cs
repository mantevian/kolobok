using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class FurnaceContainer : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        var shovel = other.gameObject.transform.parent;
        if (shovel.name == "Shovel"){
            var dough = shovel.Find("Cube").Find("Dough");
            if (dough.gameObject.activeSelf){

                // Calculate the world scale of the object before changing the parent
                Vector3 worldScale = dough.lossyScale;
                Quaternion worldRotation = dough.rotation;

                dough.SetParent(this.transform);

                transform.root.GetComponent<Game>().gameState = GameState.CLOSING_FURNACE;

                // Calculate the new local scale to maintain the same world scale
                Vector3 newLocalScale = new Vector3(
                    worldScale.x / transform.lossyScale.x,
                    worldScale.y / transform.lossyScale.y,
                    worldScale.z / transform.lossyScale.z
                );
                // Calculate the new local rotation to maintain the same world rotation
                Quaternion localRotation = Quaternion.Inverse(transform.rotation) * worldRotation;

                // Set the new local scale and position
                dough.localScale = newLocalScale;
                dough.localPosition = Vector3.zero;
                dough.localRotation = localRotation;

                
            }
        }
    }
}