using UnityEngine;
using System.Collections;
using System;

public class AI_Movement : MonoBehaviour, IDamageAble {

    public float gravity = 9.81F;
    public float m_speed = 4F;
    public float m_jump_speed = 8F;
    public float m_rot_speed = 10F;
    private float v_speed = 0F;
    private float h_speed = 0F;

    public Vector3 target; //naar private veranderen, alleen public voor inengine debuging.
    public GameController gameController;

    public int enemyDestroyScore = 100;
    public int health { get; set; }

    void Start()
    {
        health = 100;
        FindGameController();
    }

    void OnCollisionEnter() //kijkt of het object collision heeft met een ander object.
    {
        CurrentPos();
    }

    void Update()
    {
        Movement();
        if(gameObject.GetComponent<Renderer>().material.color.r >= 0.001F) //verandert de kleur van het object naar de normale kleur.
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            c.r = c.r - 0.001F;
            c.g = c.g + 0.001F;
            c.b = c.b + 0.001F;
            gameObject.GetComponent<Renderer>().material.color = c;
        }
        else
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            c.r = 0F;
            c.g = 1F;
            c.b = 1F;
            gameObject.GetComponent<Renderer>().material.color = c;
        }
    }

    private void FindGameController() //zoekt naar de gamecontroller.
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Gamecontroller not found!");
        }
    }

    private void Movement() //deze methode zorgt voor de beweging van de AI. 
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc.isGrounded) //kijkt of het poppetje zich op de grond bevind.
        {
            v_speed = 0f;
            MoveRandom(cc);
        }
        else if(gameObject.transform.position.y < -100) //kijkt of het popptje zich niet onder de y-coörd -100 bevind.
        {
            Debug.Log("Object:" + gameObject.name + " has been destroyed due too being below y: -100");
            Destroy(gameObject);
        }
        else
        {
            v_speed = gravity;
            cc.SimpleMove(new Vector3(0, v_speed, 0)); //Beweegt het poppetje naar beneden op basis van de verticale snelheid.
        }
    }

    private void MoveRandom(CharacterController cc)
    {
        if(target == new Vector3(0, 0, 0))
        {
            GenerateNewTarget(); //genereert een nieuwe positie waar het poppetje naar toe moet lopen.
        }
        else if((gameObject.transform.position.x < (target.x - 0.5F) || (gameObject.transform.position.x > (target.x + 0.5F)) 
            && (gameObject.transform.position.z < (target.z - 0.5F) || gameObject.transform.position.z > (target.z + 0.5F))))
        {
            //Debug.Log(target.x.ToString() + " " + target.y.ToString() + " " + target.z.ToString());
            //code voor rotatie naar object en bewegen naar object.
            Vector3 targetDir = target - transform.position;
            float rotate_step = m_rot_speed * Time.deltaTime; //rotatiesnelheid in deltatime.
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotate_step, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir); //zorgt er voor dat het poppetje kijkt richting de target positie.
            float m_step = m_speed * Time.deltaTime; //movement speed in deltatime.
            transform.Translate(Vector3.forward * m_step);
            //transform.Rotate(0, UnityEngine.Random.Range((m_rot_speed * -1), m_rot_speed), 0);
            //cc.SimpleMove(new Vector3(UnityEngine.Random.Range((m_speed * -1), m_speed), v_speed, 0)); // * Time.deltaTime
        }
        else
        {
            GenerateNewTarget(); //genereert een nieuwe positie waar het poppetje naar toe moet lopen.
        }
    }

    private void GenerateNewTarget()
    {
        float randomX = UnityEngine.Random.Range(0F, 100F) - 50F;
        float randomZ = UnityEngine.Random.Range(0F, 100F) - 50F;
        Vector3 newTarget = new Vector3(randomX, transform.position.y, randomZ); //new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ)
        target = newTarget;

        //target = new Vector3((transform.position.x + randomX) , transform.position.y, (transform.position.z + randomZ));
    }

    private void CurrentPos()
    {
        Debug.Log("Object:" + gameObject.name + " [POS X]" + gameObject.transform.position.x.ToString() + " [POS Y]" + gameObject.transform.position.y.ToString() + " [POS Z]" + gameObject.transform.position.z.ToString()
            + " [ROT W]" + gameObject.transform.rotation.z.ToString() + " [ROT X]" + gameObject.transform.rotation.x.ToString() + " [ROT Y]" + gameObject.transform.rotation.y.ToString() + " [ROT Z]" + gameObject.transform.rotation.z.ToString());
    }

    public void DamageCollision(int damage)
    {
        health -= damage; //trekt het aantal damage van het poppetje zijn health.
        if (health == 0 || health < 0)
        {
            Destroy(gameObject); //Verwijdert de enemy van het spel.
            gameController.AddScore(damage + enemyDestroyScore); //voegt een score toe aan de highscore.
        }
        else
        {
            gameController.AddScore(damage); //voegt een score toe aan de highscore.
        }
        Debug.Log("Object:" + gameObject.name + "[Health]" + health);
    }

    public void DamageNearby(int defaultDamage, float distance, float distanceMultiplier)
    {
        double damageDiv = Math.Pow(distanceMultiplier, distance);
        int damage = (int)((float)defaultDamage/damageDiv); 
        health -= damage;
        if (health == 0 || health < 0)
        {
            Destroy(gameObject); //Verwijdert de enemy van het spel.
            gameController.AddScore(damage + enemyDestroyScore); //voegt een score toe aan de highscore.
        }
        else
        {
            gameController.AddScore(damage); //voegt een score toe aan de highscore.
        }
        if (damage != 0)
        {
            DamageColor(); //zorgt er voor dat het object een andere kleur krijgt wanneer die damage heeft gekregen.
        }
        Debug.Log("Object: " + gameObject.name + " [Health] " + health + " [Distance]" + distance + " [Damage-Info] " + damageDiv.ToString() + " - " + damage.ToString());
    }

    public void DamageColor()
    {
        //Debug.Log("[r] " + gameObject.GetComponent<Renderer>().material.color.r.ToString() + " [g] " + gameObject.GetComponent<Renderer>().material.color.g.ToString() + " [b] " + gameObject.GetComponent<Renderer>().material.color.b.ToString() + " [a] " + gameObject.GetComponent<Renderer>().material.color.a.ToString());
        gameObject.GetComponent<Renderer>().material.color = Color.red; //Verandert de kleur van het gameobject naar rood.
        //Debug.Log("[r] " + gameObject.GetComponent<Renderer>().material.color.r.ToString() + " [g] " + gameObject.GetComponent<Renderer>().material.color.g.ToString() + " [b] " + gameObject.GetComponent<Renderer>().material.color.b.ToString() + " [a] " + gameObject.GetComponent<Renderer>().material.color.a.ToString());
    }
}
