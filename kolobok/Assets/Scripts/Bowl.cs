using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        var game = transform.root.GetComponent<Game>();

        var egg = collider.gameObject.GetComponent<Egg>();
        if (egg != null)
        {
            game.AddIngredient(Ingredient.EGG);
        }

        var butter = collider.gameObject.GetComponent<Butter>();
        if (butter != null)
        {
            game.AddIngredient(Ingredient.BUTTER);
        }

        var flour = collider.gameObject.GetComponent<Flour>();
        if (flour != null)
        {
            game.AddIngredient(Ingredient.FLOUR);
        }

        var sourCream = collider.gameObject.GetComponent<SourCream>();
        if (sourCream != null)
        {
            game.AddIngredient(Ingredient.SOURCREAM);
        }

        Destroy(collider.gameObject);
    }
}
