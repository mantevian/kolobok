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

    public Dictionary<Ingredient, GameObject> ingredients = new();
    

    void Start()
    {
        ingredients.Add(Ingredient.EGG, eggPrefab);
        ingredients.Add(Ingredient.BUTTER, butterPrefab);
        ingredients.Add(Ingredient.FLOUR, flourPrefab);
        ingredients.Add(Ingredient.SOURCREAM, sourCreamPrefab);
    }

    void Update()
    {
        
    }
}
