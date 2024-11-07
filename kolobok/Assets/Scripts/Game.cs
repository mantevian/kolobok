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
    public GameObject furnace;

    [SerializeField]
    public GameObject grandDaddy;

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
        var furn = furnace.GetComponent<Furnace>();
        // успешно приготовили
        if (furn.readiness >= 1.0d)
        {
            furn.StopCooking();
        }

        // пережарили
        if (furn.criticalHeat >= 1.0d)
        {
            furn.StopCooking();
        }

        var dad = grandDaddy.GetComponent<GrandDaddy>();

        if (dad.GetHealth() <= 0)
        {
            Lose();
        }

        if (dad.wellFed)
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
