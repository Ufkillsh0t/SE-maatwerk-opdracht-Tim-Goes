using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        Debug.Log("[Score] " + score);
    }
}
