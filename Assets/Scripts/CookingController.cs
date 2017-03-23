using UnityEngine;
using System.Collections;

public class CookingController : MonoBehaviour {
    bool OvenInRange;
    bool ServerInRange;
    string teamTag;
    string curIngredient;
    public float cookTimer = 3f;
    float cookTiming;
    GameObject container;
    public GameObject gameController;

    void Start () {
        teamTag = gameObject.tag;
        cookTiming = 3f;
        curIngredient = "";
        container = null;
	}
	
	void Update () {
	    if ((PressButton()&&(OvenInRange)&&(curIngredient == "RawMeat"))) {
            Cook();
        }  
        if ((container!=null)&&(curIngredient=="")&&(PressButton())) {
            PickupIngredient();
        }
        if ((ServerInRange)&&(PressButton())&&(curIngredient!="")) {
            DropoffIngredient();
        }
	}

    void DropoffIngredient () {
        gameController.GetComponent<GameControllerV3>().NextIngredient(curIngredient);
        curIngredient = "";
    }

    void PickupIngredient () {
        curIngredient = container.GetComponent<ItemPickup>().getFoodStuffs();
        print(teamTag + curIngredient);
    }

    void Cook () {
        cookTiming -= Time.deltaTime;
        if (cookTiming<=0) {
            curIngredient = "CookedMeat";
            cookTiming = cookTimer;
        }
    }

    bool PressButton () {
        if (Input.GetButtonDown(teamTag + "Interact")) {
            return true;
        }
        return false;
    }

    void OnTriggerEnter (Collider col) {
        GetComponent<ButtonPrompt>().PromptButtonPress();

        if (col.gameObject.tag=="Oven") {
            OvenInRange = true;
        }
        if (col.gameObject.tag == "Pickup") {
            container = col.gameObject;
        }
        if (col.gameObject.tag=="Dropoff") {
            ServerInRange = true;
        }
    }

    void OnTriggerExit (Collider col) {
        GetComponent<ButtonPrompt>().ClearButtonPrompts();

        if (col.gameObject.tag == "Appliance") {
            OvenInRange = false;
        }
        if (col.gameObject.tag == "Pickup") {
            container = null;
        }
        if (col.gameObject.tag == "Dropoff") {
            ServerInRange = false;
        }
    }

}
