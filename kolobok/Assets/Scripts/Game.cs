using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    public GameObject eggPrefab;

    [SerializeField]
    public GameObject butterPrefab;

    [SerializeField]
    public GameObject flourPrefab;

    [SerializeField]
    public GameObject sourCreamPrefab;

    [SerializeField]
    public Furnace furnace;

    [SerializeField]
    public GrandDaddy grandDaddy;

    public Dictionary<Ingredient, GameObject> ingredientPrefabs = new();

    public Dictionary<Ingredient, int> ingredientCounts = new();

    void Start()
    {
        ingredientPrefabs[Ingredient.EGG] = eggPrefab;
        ingredientPrefabs[Ingredient.BUTTER] = butterPrefab;
        ingredientPrefabs[Ingredient.FLOUR] = flourPrefab;
        ingredientPrefabs[Ingredient.SOURCREAM] = sourCreamPrefab;

        ingredientCounts[Ingredient.EGG] = 0;
        ingredientCounts[Ingredient.BUTTER] = 0;
        ingredientCounts[Ingredient.FLOUR] = 0;
        ingredientCounts[Ingredient.SOURCREAM] = 0;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        // успешно приготовили
        if (furnace.readiness >= 1.0d)
        {
            furnace.StopCooking();
        }

        // пережарили
        if (furnace.criticalHeat >= 1.0d)
        {
            furnace.StopCooking();
        }

        if (grandDaddy.GetHealth() <= 0)
        {
            Lose();
        }

        if (grandDaddy.wellFed)
        {
            Win();
        }
    }

    void Lose()
    {

    }

    void Win()
    {

    }

    public void PutIngredient(Ingredient ingredient) {
        ingredientCounts[ingredient] += 1;
    }
}
