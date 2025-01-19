using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientType type;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        var game = transform.root.GetComponent<Game>();
        if (!(game.gameState == GameState.SEARCHING_INGREDIENTS || game.gameState == GameState.PUTTING_ON_SHOVEL)) return;

        var bowlTrigger = collider.gameObject;
        var bowl = bowlTrigger.transform.parent.gameObject.GetComponent<Bowl>(); // Триггер чашки её наследник
        if (bowl == null) return;

        game.AddIngredient(type);
        game.gameState = GameState.PUTTING_ON_SHOVEL;
        Destroy(gameObject);

    }
}
