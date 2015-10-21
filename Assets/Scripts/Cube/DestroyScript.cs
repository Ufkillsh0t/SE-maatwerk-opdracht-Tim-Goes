using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Destroy(gameObject, 1); //je kan ook een field gameObject aanmaken en daarmee een andere object verwijderen. (Voor bijvoorbeeld damage etc)
            Debug.Log("This object is destroyed!");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(GetComponent<MeshRenderer>(), 1); //Verwijdert alleen de renderer van het object waardoor het object nog wel in de scene zit maar niet meer zichtbaar is ingame.
        }
	}
}
