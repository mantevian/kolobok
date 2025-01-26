using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        var shovel = other.gameObject.transform.parent;
        if (shovel.name == "Shovel"){
            Vector3 worldScale;
            Quaternion worldRotation;
            Vector3 newLocalScale;
            switch (transform.root.GetComponent<Game>().gameState)
            {
                case GameState.GIVING_TO_GRANDPA:
                    var dough = shovel.Find("Cube").Find("Kolobok");
                    if (dough.gameObject.activeSelf){

                        // Calculate the world scale of the object before changing the parent
                        worldScale = dough.lossyScale;
                        worldRotation = dough.rotation;

                        dough.SetParent(this.transform);

                        transform.root.GetComponent<Game>().gameState = GameState.FEEDING;

                        // Calculate the new local scale to maintain the same world scale
                        newLocalScale = new Vector3(
                            worldScale.x / transform.lossyScale.x,
                            worldScale.y / transform.lossyScale.y,
                            worldScale.z / transform.lossyScale.z
                        );
                        // Set the new local scale and position
                        dough.localScale = newLocalScale;
                        dough.localPosition = Vector3.zero;
                        dough.localEulerAngles = new Vector3(0, 0, 0);;

                        
                    }
                    break;
            }
        }
    }


}
