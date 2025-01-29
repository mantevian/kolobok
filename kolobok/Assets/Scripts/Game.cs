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

    private int eatingTime;

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

        eatingTime = 300;

        transform.Find("Sound").Find("StartGame").gameObject.GetComponent<AudioSource>().Play();
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

        var dadComponent = grandDaddy.GetComponent<GrandDaddy>();

        switch (gameState) {
            case GameState.FEEDING:
                if (eatingTime > -1) {
                    dadComponent.animator.SetTrigger("Eating");
                    eatingTime--;
                }

                if (eatingTime == 0) {
                    bool success = dadComponent.Eat(ingredientCounts);

                    if (success)
                    {
                        Win();
                    }
                    else
                    {
                        dadComponent.animator.SetTrigger("Angry");
                        transform.Find("Sound").Find("Angry").gameObject.GetComponent<AudioSource>().Play();
                        DecreaseAttempts();
                        dadComponent.SetButtonActive(true);
                    }
                }
            break;
        }
    }

    void Lose()
    {
        var dadComponent = grandDaddy.GetComponent<GrandDaddy>();
        dadComponent.Say("Попытки закончились. Прощайте.");
        transform.Find("Sound").Find("Death").gameObject.GetComponent<AudioSource>().Play();
        transform.Find("Sound").Find("Lose").gameObject.GetComponent<AudioSource>().Play();
        dadComponent.animator.SetTrigger("Death");
    }

    void Win()
    {
        var dadComponent = grandDaddy.GetComponent<GrandDaddy>();
        dadComponent.Say("Спасибо! Я сыт и доволен.");
        transform.Find("Sound").Find("Laugh").gameObject.GetComponent<AudioSource>().Play();
        transform.Find("Sound").Find("Victory").gameObject.GetComponent<AudioSource>().Play();
        dadComponent.animator.SetTrigger("Happy");
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
        StartGame();
    }

    public void AddIngredient(IngredientType ingredientType) {
        ingredientCounts[ingredientType] += 1;
        transform.Find("Sound").Find("AddIngredient").gameObject.GetComponent<AudioSource>().Play();
        // Log("Game bowl ingredients" + string.Join(", ", ingredientCounts.Select(entry => $"{entry.Key}: {entry.Value}").ToArray()));
    }
}
