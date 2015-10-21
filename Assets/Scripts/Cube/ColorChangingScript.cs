using UnityEngine;
using System.Collections;

public class ColorChangingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //Kijkt of de toets "R" is ingedrukt.
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red; //Verandert de kleur van het gameobject naar rood.
            Debug.Log("Cube color is now red"); //Print een lijn in het console waarin staat dat de kleur van de cube nu rood is.
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Cube color is now green");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            Debug.Log("Cube color is now blue");
        }
    }
}
