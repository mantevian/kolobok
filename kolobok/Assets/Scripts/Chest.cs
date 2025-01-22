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

    void FixedUpdate()
    {
        
    }

    void Open()
    {
        var collider = GetComponent<BoxCollider>();

        foreach (var item in defaultIngredients)
        {
            for (int i = 0; i < item.Value; i++)
            {
                Debug.Log(i);
                var obj = Instantiate(transform.root.gameObject.GetComponent<Game>().ingredientPrefabs[item.Key]);
                obj.transform.parent = transform;
                obj.transform.position = new Vector3(
                    Random.Range(collider.center.x - collider.size.x * 0.3f, collider.center.x + collider.size.x * 0.3f),
                    Random.Range(collider.center.y - collider.size.y * 0.3f, collider.center.y + collider.size.y * 0.3f),
                    Random.Range(collider.center.z - collider.size.z * 0.3f, collider.center.z + collider.size.z * 0.3f)
                ) + transform.position;
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
