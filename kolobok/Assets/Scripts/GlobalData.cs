using System.Collections;
using System.Collections.Generic;

public class GlobalData {
    public static int attempts = 5;
    
    public static Dictionary<IngredientType, int> perfectIngredients = new();

    public static InitPerfectIngredients()
    {
        perfectIngredients[IngredientType.EGG] = UnityEngine.Random.Range(2, 4);
		perfectIngredients[IngredientType.BUTTER] = UnityEngine.Random.Range(2, 4);
		perfectIngredients[IngredientType.FLOUR] = UnityEngine.Random.Range(2, 4);
    }
}