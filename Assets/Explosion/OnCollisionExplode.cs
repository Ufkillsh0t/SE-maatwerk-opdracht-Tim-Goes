using UnityEngine;
using System.Collections;
using System;

public class OnCollisionExplode : MonoBehaviour {

    public GameObject Explosion;
    public Transform Position;

    // Use this for initialization
    void OnCollisionEnter(Collision col) //Wanneer er collision is met een object.
    {
        GameObject SpawnExplosion = Instantiate(Explosion, Position.position, Position.rotation) as GameObject; //Maakt een instantie van de explosie aan
        Destroy(GetComponent<MeshRenderer>()); //Verwijerd de Meshrenderer van het object waardoor het object niet meer zichtbaar is tijdens de explosie.
    }
}
