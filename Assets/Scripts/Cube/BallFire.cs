

using UnityEngine;
using System.Collections;
using System;

public class BallFire : MonoBehaviour {

    public Rigidbody ballBody;
    public Transform spawnPos;
    public int force = 5000;
    public float fireWaitingTime = 0.5F;
    private float nextFire;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFire)
        {
            nextFire = Time.time + fireWaitingTime;
            Fire();
        }
	}

    private void Fire()
    {
        Rigidbody ballInstance;
        ballInstance = Instantiate(ballBody, spawnPos.position, spawnPos.rotation) as Rigidbody;
        ballInstance.AddForce(spawnPos.forward * force);
    }
}
