using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

    public float turnSpeed = 50F;
    public float heightSpeed = 1F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime); //Roteert het object afhankelijk van de turnSpeed en de deltatijd.
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * heightSpeed * Time.deltaTime); //Beweegt het object omhoog of omlaag  afhankelijk van de heightSpeed en de deltatijd.
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.up * heightSpeed * Time.deltaTime);
        }
    }
}
