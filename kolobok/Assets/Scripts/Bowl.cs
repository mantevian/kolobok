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

        var ingredient = collider.gameObject.GetComponent<Ingredient>();
        if (ingredient != null)
        {
            game.AddIngredient(ingredient.type);
            Destroy(collider.gameObject);
        }
    }
}
