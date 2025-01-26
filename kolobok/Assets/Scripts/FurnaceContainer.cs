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
            Vector3 worldScale;
            Quaternion worldRotation;
            Vector3 newLocalScale;
            switch (transform.root.GetComponent<Game>().gameState)
            {
                case GameState.PUTTING_IN_FURNACE:
                    var dough = shovel.Find("Cube").Find("Dough");
                    if (dough.gameObject.activeSelf){

                        // Calculate the world scale of the object before changing the parent
                        worldScale = dough.lossyScale;
                        worldRotation = dough.rotation;

                        dough.SetParent(this.transform);

                        transform.root.GetComponent<Game>().gameState = GameState.CLOSING_FURNACE;

                        // Calculate the new local scale to maintain the same world scale
                        newLocalScale = new Vector3(
                            worldScale.x / transform.lossyScale.x,
                            worldScale.y / transform.lossyScale.y,
                            worldScale.z / transform.lossyScale.z
                        );
                        // Set the new local scale and position
                        dough.localScale = newLocalScale;
                        dough.localPosition = Vector3.zero;
                        dough.localEulerAngles = new Vector3(90, 0, 0);;

                        
                    }
                    break;
                case GameState.GRABBING_COOKED:
                    var shovelContainer = shovel.Find("Cube");
                    var kolobok = transform.Find("Kolobok");

                    // Calculate the world scale of the object before changing the parent
                    worldScale = kolobok.lossyScale;
                    worldRotation = kolobok.rotation;

                    kolobok.SetParent(shovelContainer);

                    transform.root.GetComponent<Game>().gameState = GameState.GIVING_TO_GRANDPA;

                    // Calculate the new local scale to maintain the same world scale
                    newLocalScale = new Vector3(
                        worldScale.x / shovelContainer.lossyScale.x,
                        worldScale.y / shovelContainer.lossyScale.y,
                        worldScale.z / shovelContainer.lossyScale.z
                    );

                    // Set the new local scale and position
                    kolobok.localScale = newLocalScale;
                    kolobok.localPosition = Vector3.zero;
                    kolobok.localEulerAngles = new Vector3(-90, 0, 0);
                    break;
            }
        }
    }
}