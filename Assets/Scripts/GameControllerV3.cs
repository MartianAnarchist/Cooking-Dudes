using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerV3 : MonoBehaviour {
    public string[] foodStuffs = new string[5];
    public string Recipe;
    public string dish;

    void Start() {
        dish = "";
    }

    void Update() {
        //if ((dish.Length>Recipe.Length)&&(dish!=Recipe)) {
        //    ResetDish();
        //}
    }

    // Cooking
    void CompareStuff() {
        if (CheckFinalDish()) {
            print("Dish Complete, Good Job Chef");
            NewRecipe();
            return;
        }
    }

    bool CheckFinalDish() {
        if (dish == Recipe) {
            return true;
        }
        return false;
    }

    public void ResetDish() {
        print("Dish Reset");
        dish = "";
    }

    public void NextIngredient(string ingredient) {
        dish += ingredient + " ";
        CompareStuff();
    }



    //Recipe Selection
    void NewRecipe () {
        ResetDish();
        MakeRecipe();    
    }

    int NumberOfIngredients() {
        int numIng = Random.Range(0, 6);
        return numIng;
    }

    string PickIngredient () {
        string tempIngredient = "";
        tempIngredient = foodStuffs[Random.Range(0, foodStuffs.Length)];
        return tempIngredient;
    }

    void MakeRecipe () {
        string tempRecipe = "Bread ";
        for (int i = 0; i < NumberOfIngredients(); i++) {
            tempRecipe += PickIngredient() + " ";
        }
        tempRecipe += "Bread ";
        Recipe = tempRecipe;
    }


}
