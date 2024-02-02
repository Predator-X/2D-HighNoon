using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {
    private Transform target;

    public float boundsTop = 6.0f;
    public float boundsBottom = -1.0f;
    public float boundsLeft = 5.0f;
    public float boundsRight = 5.0f;
    public float[] layerSpeeds;
    public GameObject[] layers;
    public Vector2 baseLocation,movementFromBase;
   
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        baseLocation = target.position;
     }

	void Update ()
    {
        float clampX = Mathf.Clamp(target.position.x, boundsLeft, boundsRight);
        float clampY = Mathf.Clamp(target.position.y, boundsTop, boundsBottom);
        //transform.position = new Vector3(Mathf.Clamp(Time.time,target.position.x,clampX), Mathf.Clamp(Time.time, target.position.y, clampY), transform.position.z);
        //transform.position = new Vector3(target.position.x, target.position.y,transform.position.z);
         transform.position = new Vector3(clampX, clampY, transform.position.z);
         movementFromBase = (Vector2)target.transform.position - baseLocation;
        if (layers.Length > 0)
        {
            int i = 0;
            foreach(GameObject layer in layers)
            {
                Material mat = layer.GetComponent<Renderer>().material;
                mat.SetTextureOffset("_MainTex", new Vector2((movementFromBase.x*(layerSpeeds[i] * 0.05f)), 0.0f));
                i++;
            }
        }
	}
}
