using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

    int numBGPanels = 6;

	void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered: " + collider.name);

        float widthOfBGObject = ((BoxCollider2D)collider).size.x;

        Vector3 pos = collider.transform.position;

        pos.x += widthOfBGObject * numBGPanels - widthOfBGObject/2f;

        collider.transform.position = pos;
    }

}
