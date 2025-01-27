using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject grandDaddy;

    [SerializeField]
    public GameObject doorToHide;

    [SerializeField]
    public GameObject startGameButton;

    [SerializeField]
    public GameObject startGameText;

    [SerializeField]
    public GameObject chestOpen;

    [SerializeField]
    public GameObject chestClosed;

    [SerializeField]
    public GameObject debugOutput;

    [SerializeField]
    public GameObject gameStateOutput;
    
    [SerializeField]
    public GameState gameState = GameState.SEARCHING_INGREDIENTS;

    public Dictionary<IngredientType, GameObject> ingredientPrefabs = new();

    public Dictionary<IngredientType, int> ingredientCounts = new();

    public List<string> debugLines;

    public void Start()
    {
        ingredientPrefabs[IngredientType.EGG] = eggPrefab;
        ingredientPrefabs[IngredientType.BUTTER] = butterPrefab;
        ingredientPrefabs[IngredientType.FLOUR] = flourPrefab;

        ingredientCounts[IngredientType.EGG] = 0;
        ingredientCounts[IngredientType.BUTTER] = 0;
        ingredientCounts[IngredientType.FLOUR] = 0;

        grandDaddy.GetComponent<GrandDaddy>().SetButtonActive(false);
    }

    public void StartGame()
    {
        doorToHide.SetActive(false);
        startGameButton.GetComponent<Button>().interactable = false;
        startGameText.GetComponent<Text>().text = "Игра идёт!";
        
        chestClosed.SetActive(false);
        chestOpen.SetActive(true);
    }

    public void Log(string text)
    {
        Debug.Log(text);
        debugLines.Add(text);
        if (debugLines.Count > 7)
        {
            debugLines.RemoveAt(0);
        }
        string result = String.Join("\n", debugLines);
        debugOutput.GetComponent<Text>().text = result;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        gameStateOutput.GetComponent<Text>().text = gameState.ToString();
    }

    void Lose()
    {
        // А тут чё делать?
    }

    void Win()
    {
        // И тут чё делать?
    }

    public void DecreaseAttempts() {
        GlobalData.attempts -= 1;
    }

    public void NextAttempt() {
        if (GlobalData.attempts <= 0)
        {
            Lose();
            return;
        }

        GetComponent<SceneResetter>().ResetScene();
    }

    public void AddIngredient(IngredientType ingredientType) {
        ingredientCounts[ingredientType] += 1;
        Log("Game bowl ingredients" + string.Join(", ", ingredientCounts.Select(entry => $"{entry.Key}: {entry.Value}").ToArray()));
    }
}
