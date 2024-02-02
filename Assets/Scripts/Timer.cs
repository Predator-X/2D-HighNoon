using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    public bool gameInProgress = true;
    public Text timerText;
    public GameObject Player;

    public float valueRemaining, valueConsumptionRate;

	void Update ()
    {
        if (gameInProgress)
        {
            valueRemaining -= Time.deltaTime * valueConsumptionRate;
            timerText.text = "Time Remaining: " + Mathf.Round(valueRemaining).ToString();
           if (valueRemaining < 0){  gameInProgress = false;   endGameWithFailure(); }
        }	
	}
   void endGameWithFailure() { PeristentManager.dataStore.endGameWithLoss(); }//Player.SetActive(false);
}
