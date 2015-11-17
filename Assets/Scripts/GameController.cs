using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public int score = 0;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score: " + score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("[Score] " + score);
    }
}
