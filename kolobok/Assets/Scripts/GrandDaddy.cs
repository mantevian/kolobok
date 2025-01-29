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

	[SerializeField]
	public GameObject furnace;

	public Animator animator;

	

    void Start()
    {
        Reset();

		animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

    }

	public void Reset()
	{
		
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

		result[IngredientType.EGG] = ingredients[IngredientType.EGG] - GlobalData.perfectIngredients[IngredientType.EGG];
		result[IngredientType.BUTTER] = ingredients[IngredientType.BUTTER] - GlobalData.perfectIngredients[IngredientType.BUTTER];
		result[IngredientType.FLOUR] = ingredients[IngredientType.FLOUR] - GlobalData.perfectIngredients[IngredientType.FLOUR];

		return result;
	}

	public bool Eat(Dictionary<IngredientType, int> ingredients)
	{
		var result = new List<string>();

		var numberedResults = GetResults(ingredients);

		var furn = furnace.GetComponent<Furnace>();

		if (furn.readiness < 0.8d) result.Add("Колобок слишком сырой");
		if (furn.readiness > 1.2d) result.Add("Колобок пережаренный");

		if (numberedResults[IngredientType.EGG] < 0) result.Add("Недостаточно яиц");
		if (numberedResults[IngredientType.EGG] > 0) result.Add("Слишком много яиц");
		
		if (numberedResults[IngredientType.BUTTER] < 0) result.Add("Недостаточно масла");
		if (numberedResults[IngredientType.BUTTER] > 0) result.Add("Слишком много масла");

		if (numberedResults[IngredientType.FLOUR] < 0) result.Add("Недостаточно муки");
		if (numberedResults[IngredientType.FLOUR] > 0) result.Add("Слишком много муки");

		if (
				numberedResults[IngredientType.EGG] != 0
				|| numberedResults[IngredientType.BUTTER] != 0
				|| numberedResults[IngredientType.FLOUR] != 0
				|| furn.readiness < 0.8d
				|| furn.readiness > 1.2d
			)
		{
			result.Add("Осталось попыток: " + (GlobalData.attempts - 1));
			Say(string.Join(Environment.NewLine, result));
			return false;
		}

		result.Add("Идеально!");

		Say(string.Join(Environment.NewLine, result));

		return true;
	}
}
