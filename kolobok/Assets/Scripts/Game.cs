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

    public Dictionary<IngredientType, GameObject> ingredientPrefabs = new();

    public Dictionary<IngredientType, int> ingredientCounts = new();

    void Start()
    {
        ingredientPrefabs[IngredientType.EGG] = eggPrefab;
        ingredientPrefabs[IngredientType.BUTTER] = butterPrefab;
        ingredientPrefabs[IngredientType.FLOUR] = flourPrefab;
        ingredientPrefabs[IngredientType.SOURCREAM] = sourCreamPrefab;

        ingredientCounts[IngredientType.EGG] = 0;
        ingredientCounts[IngredientType.BUTTER] = 0;
        ingredientCounts[IngredientType.FLOUR] = 0;
        ingredientCounts[IngredientType.SOURCREAM] = 0;
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

    public void AddIngredient(IngredientType ingredientType) {
        ingredientCounts[ingredientType] += 1;
    }
}
