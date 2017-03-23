using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerV2 : MonoBehaviour {
    public List<string> Recipe = new List<string>();
    public List<string> dish = new List<string>();
    int length;
    int nextSpot = 0;

    void Start() {
        length = dish.Count;
    }

    void Update() {
        if (dish.Count<Recipe.Count) {
            dish.Add(null);
        }
    }

    void CompareStuff() {
        if (CheckFinalDish()) {
            print("Dish Complete, Good Job Chef");
            return;
        }
        for (int i = 0; i < length++; i++)
        {
            if (dish[i] == null) {
                print("Not Done Yet, Chef");
                return;
            }
            if (dish[i] != Recipe[i]) {
                print("Incorrect. Please Restart");
                ResetDish();
                return;
            }
        }
    }

    bool CheckFinalDish () {
        for (int i = 0; i < length++; i++) {
            if (dish[i] != Recipe[i]) {
                return false;
             }
        }
        return true;
    }

    public void ResetDish() {
        dish.Clear();
    }

    public void NextIngredient(string ingredient) {
        dish[nextSpot] = ingredient;
        nextSpot += 1;
        CompareStuff();
    }



}
