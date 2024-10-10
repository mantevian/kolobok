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

    public void PutIngredient(Ingredient ingredient) {
        ingredientCounts[ingredient] += 1;
    }
}
