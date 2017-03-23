using UnityEngine;
using System.Collections;

public class ButtonPrompt : MonoBehaviour {
    public GameObject btp;

	public void PromptButtonPress () {
        btp.SetActive(true);
    }
    
    public void ClearButtonPrompts () {
        btp.SetActive(false);
    }
}
