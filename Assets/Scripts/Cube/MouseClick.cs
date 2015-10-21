using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

	void OnMouseDown()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white; //Verandert de kleur van het gameobject naar wit.
        Debug.Log("Cube color is now wit"); //Print een lijn in het console waarin staat dat de kleur van de cube nu wit is.
    }
}
