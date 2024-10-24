using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Dictionary<IngredientType, int> defaultIngredients = new();

    void Start()
    {
        defaultIngredients.Add(IngredientType.EGG, 2);
        defaultIngredients.Add(IngredientType.BUTTER, 4);
        defaultIngredients.Add(IngredientType.FLOUR, 6);
        defaultIngredients.Add(IngredientType.SOURCREAM, 10);
    }

    void Update()
    {
        
    }

    void Open()
    {
        foreach (var item in defaultIngredients)
        {
            for (int i = 0; i < item.Value; i++)
            {
                var obj = Instantiate(transform.root.gameObject.GetComponent<Game>().ingredientPrefabs[item.Key]);
                obj.transform.parent = transform;
            }
        }
    }

    void Close()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
