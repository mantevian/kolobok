using System.Collections;
using System.Collections.Generic;

public class GlobalData {
    public static int attempts = 5;

    public static bool gonnaReset = false;

    public static bool autostart = false;
    
    public static Dictionary<IngredientType, int> perfectIngredients = new Dictionary<IngredientType, int>
    {
        { IngredientType.EGG, UnityEngine.Random.Range(2, 4) },
        { IngredientType.BUTTER, UnityEngine.Random.Range(2, 4) },
        { IngredientType.FLOUR, UnityEngine.Random.Range(2, 4) }
    };

    public static void Reset()
    {
        attempts = 5;

        gonnaReset = false;

        autostart = false;

        perfectIngredients = new Dictionary<IngredientType, int>
        {
            { IngredientType.EGG, UnityEngine.Random.Range(2, 4) },
            { IngredientType.BUTTER, UnityEngine.Random.Range(2, 4) },
            { IngredientType.FLOUR, UnityEngine.Random.Range(2, 4) }
        };
    }
}