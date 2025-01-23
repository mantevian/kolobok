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

	public bool Eat(Dictionary<IngredientType, int> ingredients)
	{
		SetButtonActive(true);

		var result = new List<string>();

		result.Add("Осталось попыток: " + GlobalData.attempts);

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

		// Если есть хотя бы одна ошибка в ингредиентах, пишем результат. Если ошибок нет, цикл пройдёт полностью и в результат добавится "Идеально!"
		foreach (var item in perfectIngredients)
		{
			if (perfectIngredients[item.Key] != ingredients[item.Key])
			{
				Say(string.Join(Environment.NewLine, result));
				return false;
			}
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
