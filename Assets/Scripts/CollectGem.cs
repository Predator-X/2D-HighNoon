using UnityEngine;
using System.Collections;

public class CollectGem : MonoBehaviour
{
   // Rigidbody2D
     //  public GameObject gem;
    public AudioClip soundEffect;

    public void OnTriggerEnter2D(Collider2D target)
    {
        //gem.setActive(false);
        PeristentManager.dataStore.gemsCollected += 1;
        if (target.gameObject.tag == "Player")
        {
            if (soundEffect) { AudioSource.PlayClipAtPoint(soundEffect, transform.position); }
        }
        Destroy(gameObject);
    }
}
