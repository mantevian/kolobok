using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject furnace;

    [SerializeField]
    public GameObject grandDaddy = null;
    
    [SerializeField]
    public GameState gameState = GameState.SEARCHING_INGREDIENTS;

    public Dictionary<IngredientType, GameObject> ingredientPrefabs = new();

    public Dictionary<IngredientType, int> ingredientCounts = new();

    void Start()
    {
        ingredientPrefabs[IngredientType.EGG] = eggPrefab;
        ingredientPrefabs[IngredientType.BUTTER] = butterPrefab;
        ingredientPrefabs[IngredientType.FLOUR] = flourPrefab;

        ingredientCounts[IngredientType.EGG] = 0;
        ingredientCounts[IngredientType.BUTTER] = 0;
        ingredientCounts[IngredientType.FLOUR] = 0;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        // TODO UNCOMMENT WHEN GRANDDADDY IS ADDED!!!
        /*
        var dad = grandDaddy.GetComponent<GrandDaddy>();

        if (dad.GetHealth() <= 0)
        {
            Lose();
        }

        if (dad.wellFed)
        {
            Win();
        }
        */
    }

    void Lose()
    {

    }

    void Win()
    {

    }

    public void AddIngredient(IngredientType ingredientType) {
        ingredientCounts[ingredientType] += 1;
        Debug.Log("Game bowl ingredients" + string.Join(", ", ingredientCounts.Select(entry => $"{entry.Key}: {entry.Value}").ToArray()));
    }
}
