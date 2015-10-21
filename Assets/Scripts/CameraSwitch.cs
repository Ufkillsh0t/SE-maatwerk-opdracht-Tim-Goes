using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

    private bool isSecondary;
    public GameObject mainCamera;
    public GameObject cubeCamera;

	// Use this for initialization
	void Start () {
        isSecondary = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isSecondary = !isSecondary;
        }

        if (!isSecondary)
        {
            mainCamera.SetActive(true);
            cubeCamera.SetActive(false);
        }
        else
        {
            mainCamera.SetActive(false);
            cubeCamera.SetActive(true);
        }
	}
}
