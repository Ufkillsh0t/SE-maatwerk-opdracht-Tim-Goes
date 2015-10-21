using UnityEngine;
using System.Collections;

public class BallDestruction : MonoBehaviour {

    public AudioClip destructionSound;
    public int defaultDamage = 250;
    public float damageDistanceMultiplier = 1.1F;
    public float radius = 50F;

    // Use this for initialization
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = destructionSound;
        audio.Play();
    }

    //Wanneer er collision is met dit object wordt de volgende code uitgevoerd.
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Object has collision");
        //misschien overbodig {
        IDamageAble hit = col.collider.gameObject.GetComponent<IDamageAble>(); //zorgt er voor dat het object waarmee gecolide wordt damage krijgt.
        if(hit != null)
        {
            hit.DamageCollision(defaultDamage);
        }
        //misschien overbodig }
        DamageNearbyEnemyObjects();
        Explosion();
    }

    void Update()
    {
        if(gameObject.transform.position.y < -100) //Wanneer de huidige positie van de sphere onder y = -100 zit wordt die verwijdert aangezien dat al redelijk onder de map zit.
        {
            Explosion();
        }
    }

    
    /* Oud damage code
    GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy"); //Zoekt naar alle objecten met de tag enemy
    foreach(GameObject g in gos)
    {
        IDamageAble damage = g.gameObject.GetComponent<IDamageAble>();
        if(damage != null)
        {
            damage.DamageNearby(defaultDamage, Vector3.Distance(gameObject.transform.position, g.transform.position), 2F);
        }
    }*/

    private void DamageNearbyEnemyObjects()
    {
        RaycastHit[] hit = Physics.SphereCastAll(new Ray(gameObject.transform.position, new Vector3(1, 0, 1)), radius); //Voert een spherecast uit en slaat alle objecten op die het raakt binnen een bepaalde afstand.
        foreach(RaycastHit r in hit)
        {
            IDamageAble damage = r.transform.gameObject.GetComponent<IDamageAble>();
            if(damage != null)
            {
                damage.DamageNearby(defaultDamage, Vector3.Distance(gameObject.transform.position, r.transform.position), damageDistanceMultiplier);
            }
        }
    }

    private void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation); //Maakt een explosie aan op de locatie van de sphere.
        Debug.Log("Object : " + gameObject.name + "has been destroyed at, y:" + gameObject.transform.position.y.ToString() + "x:" + gameObject.transform.position.x.ToString() + "z:" + gameObject.transform.position.z.ToString());
        Destroy(gameObject); //Verwijdert de sphere van het spel.
    }
}
