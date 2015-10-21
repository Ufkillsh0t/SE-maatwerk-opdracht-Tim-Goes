using UnityEngine;
using System.Collections;

public class ExplosionDestroy : MonoBehaviour {

    //public float DestrucionTime; Voor als jezelf de destructietijd wilt bepalen

    // Use this for initialization
    void Start () {
        var system = GetComponentInChildren<ParticleSystem>(); //Verkrijgt het particlesysteem van de explosie
        Destroy(gameObject, system.duration); //Verkrijgt de duratie van het particlesysteem
        //Destroy(transform.parent.gameObject, system.duration); //Verwijderd de parent.
	}
}
