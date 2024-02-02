using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Collected : MonoBehaviour {
    public Text collected;

	void Start () {
	
	}
	

	void Update () {
        collected.text = "Gems Collected :" + PeristentManager.dataStore.getGemsCollected();

    }
}
