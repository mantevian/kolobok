using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CircleLoaderTrigger : MonoBehaviour
{
        
    public HashSet<ActionBasedController> entered = new();
    
    void OnTriggerEnter(Collider collider)
    {
        var controller = collider.gameObject.transform.parent.gameObject.GetComponent<ActionBasedController>();
        Debug.Log(collider.gameObject.transform.parent.gameObject);
        if (controller != null){
            Debug.Log("Controller entered");

            entered.Add(controller);
        }
        
        
    }
    void OnTriggerExit(Collider collider)
    {
        var controller = collider.gameObject.transform.parent.gameObject.GetComponent<ActionBasedController>();
        Debug.Log("Collision exited");
        if (controller != null){
            Debug.Log("Controller exited");

            entered.Remove(controller);
        }
    }
}
