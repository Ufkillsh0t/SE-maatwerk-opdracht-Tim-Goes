using UnityEngine;
using System.Collections;

public class LightToggle : MonoBehaviour {

    private Light blueLight;

	// Use this for initialization
	void Start () {
        blueLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            blueLight.enabled = !blueLight.enabled; //Enabled of Disabled bluelight afhankelijk van de staat van het object.
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            LightningUp(); //Veranderd de kleur van het light een beetje.
        }
	}

    private void LightningUp()
    {
        Color newColor = blueLight.color;
        if (newColor.r >= 1F)
        {
            newColor.r = 0F;
            if (newColor.g >= 1F)
            {
                newColor.g = 0F;
                if(newColor.b >= 1F)
                {
                    newColor.b = 0F;
                }
                else
                {
                    newColor.b += 0.005F;
                }
            }
            else
            {
                newColor.g += 0.005F;
            }
        }
        else
        {
            newColor.r += 0.005F;
        }

        blueLight.color = newColor;
    }
}
