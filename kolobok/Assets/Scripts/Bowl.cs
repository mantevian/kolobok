using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        var game = transform.root.GetComponent<Game>();
        var shovelTrigger = collider.gameObject;

        if (shovelTrigger.GetComponent<ShovelController>() is null 
            || !game.ingredientCounts.Values.Any(value => value > 0) 
            || game.gameState != GameState.PUTTING_ON_SHOVEL
        ) 
            return;
        if (transform.up.y > 0) return;
        
        shovelTrigger.GetComponent<ShovelController>().putDough();
        game.gameState = GameState.PUTTING_IN_FURNACE;
    }
}
