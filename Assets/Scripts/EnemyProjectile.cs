using UnityEngine;
using System.Collections;
using System;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 20.0f;
    private Vector2 direction = new Vector2(-1, 0);
    private SpPlayerController player;
    private AudioSource audioSFX;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<SpPlayerController>();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        audioSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            player.RecieveDamage(5);
            PlayVFX();
            Destroy(gameObject);
        }
    }

    private void PlayVFX()
    {
        if (audioSFX != null)
            audioSFX.Play();
    }
}
