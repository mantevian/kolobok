using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GrandDaddy : MonoBehaviour
{
	[SerializeField]
	public GameObject speech;

	[SerializeField]
	public GameObject button;

	[SerializeField]
	public GameObject game;

	public Dictionary<IngredientType, int> perfectIngredients = new();

    void Start()
    {
        Reset();
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

	public void Say(string text) {
		speech.GetComponent<Text>().text = text;
	}

	public void SetButtonActive(bool active) {
		button.SetActive(active);
	}

	public Dictionary<IngredientType, int> GetResults(Dictionary<IngredientType, int> ingredients)
	{
		var result = new Dictionary<IngredientType, int>();

		result[IngredientType.EGG] = ingredients[IngredientType.EGG] - perfectIngredients[IngredientType.EGG];
		result[IngredientType.BUTTER] = ingredients[IngredientType.BUTTER] - perfectIngredients[IngredientType.BUTTER];
		result[IngredientType.FLOUR] = ingredients[IngredientType.FLOUR] - perfectIngredients[IngredientType.FLOUR];

		return result;
	}

	public bool Eat(Dictionary<IngredientType, int> ingredients)
	{
		SetButtonActive(true);

		var result = new List<string>();

		var numberedResults = GetResults(ingredients);

		result.Add("Осталось попыток: " + GlobalData.attempts);

		switch (numberedResults[IngredientType.EGG])
		{
			case -1: result.Add("Недостаточно яиц"); break;
			case 1: result.Add("Слишком много яиц"); break;
		}

		switch (numberedResults[IngredientType.BUTTER])
		{
			case -1: result.Add("Недостаточно масла"); break;
			case 1: result.Add("Слишком много масла"); break;
		}

		switch (numberedResults[IngredientType.FLOUR])
		{
			case -1: result.Add("Недостаточно муки"); break;
			case 1: result.Add("Слишком много муки"); break;
		}

		if (numberedResults[IngredientType.EGG] == 0 && numberedResults[IngredientType.BUTTER] == 0 && numberedResults[IngredientType.FLOUR] == 0)
		{
			Say(string.Join(Environment.NewLine, result));
			return false;
		}

		result.Add("Идеально!");

		Say(string.Join(Environment.NewLine, result));

		return true;
	}

	void OnTriggerEnter(Collider collider)
    {
		// Здесь надо вместо false проверить, это коллижн с колобком ли, и достать ингредиенты
		/*
        if (false)
		{
			Dictionary<IngredientType, int> ingredients = new();

			bool success = Eat(ingredients);

			if (success)
			{
				game.GetComponent<Game>().Win();
			}
			else
			{
				game.GetComponent<Game>().DecreaseAttempts();
			}
		}
		*/
    }
}
