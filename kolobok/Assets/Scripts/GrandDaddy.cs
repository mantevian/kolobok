using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandDaddy : MonoBehaviour
{
	public Dictionary<IngredientType, int> perfectIngredients = new();

	private int health = 5;

	public bool wellFed = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {

    }

	public void Reset()
	{
		perfectIngredients[IngredientType.EGG] = UnityEngine.Random.Range(2, 5);
		perfectIngredients[IngredientType.BUTTER] = UnityEngine.Random.Range(2, 5);
		perfectIngredients[IngredientType.FLOUR] = UnityEngine.Random.Range(2, 5);
		perfectIngredients[IngredientType.SOURCREAM] = UnityEngine.Random.Range(2, 5);
	}

	public int GetHealth()
	{
		return health;
	}

	public void Eat(Dictionary<IngredientType, int> ingredients)
	{
		foreach (var item in perfectIngredients)
		{
			if (perfectIngredients[item.Key] != ingredients[item.Key])
			{
				health--;
				return;
			}
		}
	}
}
