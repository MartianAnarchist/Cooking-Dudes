using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public List<string> Recipe = new List<string>();
    List<string> dish = new List<string>();


    void Start () {
	    
	}
	
	
	void Update () {
	
	}

    void CompareStuff () {
        for (int i = 0; i<Recipe.Count;i++) {
            if (dish.GetRange(i,i++)== null) {
                print("Not Done Yet, Chef");
                return;
            }
            if (dish.GetRange(i, i++) != Recipe.GetRange(i, i++)) {
                print("Incorrect. Please Restart");
                ResetDish();
                return;
            }
        }
    }

    public void ResetDish () {
        dish.Clear();
    }

    public void NextIngredient (string ingredient) {
        dish.Add(ingredient);
        CompareStuff();
    }



}
