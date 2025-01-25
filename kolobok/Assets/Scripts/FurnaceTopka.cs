using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceTopka : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        if (!other.gameObject.CompareTag("Wood")) return;
        transform.parent.GetComponent<Furnace>().AddWood();
        Destroy(other.gameObject);
    }
}
