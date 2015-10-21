using UnityEngine;
using System.Collections;

public class DestroyAfterSound : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
