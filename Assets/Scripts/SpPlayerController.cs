using UnityEngine;
using System.Collections;
using System;

public class SpPlayerController : MonoBehaviour {
    public float HP = 100;
    public float speed = 4.0f;
    public Boundary boundary;

    public GameObject projectile;
    public Transform projectileSpawnLocation;
    public float fireRate;

    public float countdown = 0.15f;
    private Rigidbody2D rigidbody;
    private int maxHealth = 100;
    private AudioSource[] audioSource;
    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }
    
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        this.transform.position = new Vector3(-12.75f, 0, 0);
        audioSource = GetComponents<AudioSource>();
    }

    internal void RecieveDamage(int v)
    {
        HP -= v;

        if (HP <= 0)
        {
            GameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        countdown -= Time.deltaTime;
        if (Input.GetButton("Fire1") && countdown <= 0.0f)
        {
            countdown = 0.25f;
            Instantiate(projectile, projectileSpawnLocation.position, projectileSpawnLocation.rotation);
            PlayFireSound();
        }
            
	}

    private void PlayFireSound()
    {
        if(audioSource!=null)
        {
            audioSource[0].Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector2
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax)
        );
        
    }

    public string getHP()
    {
        return HP.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Alien"))
        {
            RecieveDamage(10);
            PlayHitSound();
        }
            
        else if (other.gameObject.tag.Equals("FixItem"))
        {
            FixSpaceShip(15);
            PlayFixSound();
        }
            
    }

    private void PlayFixSound()
    {
        if (audioSource != null)
        {
            audioSource[2].Play();
        }
    }

    private void PlayHitSound()
    {
        if (audioSource != null)
        {
            audioSource[1].Play();
        }
    }

    private void FixSpaceShip(int i)
    {
        if(HP + i > 100)
        {
            HP = 100;
        }
        else
        {
            HP += i;
        } 
    }
}
