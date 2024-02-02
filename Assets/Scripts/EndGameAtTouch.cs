using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagment;

public class EndGameAtTouch : MonoBehaviour {
    public bool endWinthWin;

    void OnTriggerExit2D(Collider2D target)
    {
      //  PeristentManager.dataStore.endGameWithWin();
        if (target.gameObject.tag == "Player")
        {
            PeristentManager.dataStore.endGameWithWin();
        }
    }
	
}
