using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ShovelController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void putDough(){
        gameObject.GetNamedChild("Dough").SetActive(true);
    }

    void OnTriggerEnter(Collider collider) {
        var game = transform.root.GetComponent<Game>();
        var bowl = collider.gameObject;

        if (bowl.GetComponent<Bowl>() is null || !game.ingredientCounts.Any()) return;
        if (bowl.transform.up.y > 0) return;

        putDough();
    }

    
}
