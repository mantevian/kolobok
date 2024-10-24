using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandDaddy : MonoBehaviour
{
	public Dictionary<Ingredient, int> perfectIngredients = new();

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
		perfectIngredients[Ingredient.EGG] = UnityEngine.Random.Range(2, 5);
		perfectIngredients[Ingredient.BUTTER] = UnityEngine.Random.Range(2, 5);
		perfectIngredients[Ingredient.FLOUR] = UnityEngine.Random.Range(2, 5);
		perfectIngredients[Ingredient.SOURCREAM] = UnityEngine.Random.Range(2, 5);
	}

	public int GetHealth()
	{
		return health;
	}

	public void Eat(Dictionary<Ingredient, int> ingredients)
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
