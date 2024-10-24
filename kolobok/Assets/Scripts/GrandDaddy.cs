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
		int difference = 0;
		int sum = 0;

		foreach (var item in perfectIngredients)
		{
			difference += Math.Abs(perfectIngredients[item.Key] - ingredients[item.Key]);
			sum += perfectIngredients[item.Key];
		}

		double satisfaction = 1.0d - difference / sum;

		if (satisfaction > 0.9d)
		{
			wellFed = true;
		}
		else
		{
			health--;
		}
	}
}
