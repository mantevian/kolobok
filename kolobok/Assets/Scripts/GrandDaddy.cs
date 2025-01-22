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
	}

	public int GetHealth()
	{
		return health;
	}

	public List<String> Eat(Dictionary<IngredientType, int> ingredients)
	{
		var result = new List<String>();

		if (ingredients[IngredientType.EGG] < perfectIngredients[IngredientType.EGG])
		{
			result.Add("Недостаточно яиц");
		}
		else if (ingredients[IngredientType.EGG] > perfectIngredients[IngredientType.EGG])
		{
			result.Add("Слишком много яиц");
		}

		if (ingredients[IngredientType.BUTTER] < perfectIngredients[IngredientType.BUTTER])
		{
			result.Add("Недостаточно масла");
		}
		else if (ingredients[IngredientType.BUTTER] > perfectIngredients[IngredientType.BUTTER])
		{
			result.Add("Слишком много масла");
		}

		if (ingredients[IngredientType.FLOUR] < perfectIngredients[IngredientType.FLOUR])
		{
			result.Add("Недостаточно муки");
		}
		else if (ingredients[IngredientType.FLOUR] > perfectIngredients[IngredientType.FLOUR])
		{
			result.Add("Слишком много муки");
		}

		foreach (var item in perfectIngredients)
		{
			if (perfectIngredients[item.Key] != ingredients[item.Key])
			{
				health--;
				return result;
			}
		}

		result.Add("Идеально!");

		return result;
	}
}
