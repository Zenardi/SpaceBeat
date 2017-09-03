using UnityEngine;
using System.Collections;
using System;

public class Alien : MonoBehaviour
{
    public int hp = 5; // TODO Play test 
    private float countdown = 1.0f;
    private Vector2 direction = new Vector2(-1, 0);
    public float speed = 2;
    public Transform projectileSpawnLocation;
    public GameObject projectile;
    public GameObject explosionAnimation;
    private AudioSource[] audioSource;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        GetComponent<Rigidbody2D>().rotation = -90;
        //projectile = FindObjectOfType<EnemyProjectile>();
        audioSource = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
            PlayFiringSound();
            Fire();
            countdown = 1.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if collide with player auto destroy
        // if collide with projectile recieve damage
        if(other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("PlayerProjectile"))
        {
            PlayHitSound();
            var expl = Instantiate(explosionAnimation, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);          
            Destroy(expl, 3); // delete the explosion after 3 seconds
        }
            
    }

    private void PlayHitSound()
    {
        if(audioSource!=null)
        {
            audioSource[1].Play();
        }
    }

    void Fire()
    {
        Instantiate(projectile, projectileSpawnLocation.position, Quaternion.identity);
        
    }

    private void PlayFiringSound()
    {
        if(audioSource!=null)
        {
            audioSource[0].Play();
        }
            
    }
}
