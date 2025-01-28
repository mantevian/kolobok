using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField]
    public GameObject doughInBowl;

    void Start()
    {
        doughInBowl.SetActive(false);
    }

    void FixedUpdate()
    {
        var game = transform.root.GetComponent<Game>();
        int count = game.ingredientCounts[IngredientType.EGG] + game.ingredientCounts[IngredientType.BUTTER] + game.ingredientCounts[IngredientType.FLOUR];
        doughInBowl.transform.localPosition = new Vector3(0.0f, 0.0f, 0.008f * count);
    }

    void OnTriggerStay(Collider collider) {
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
