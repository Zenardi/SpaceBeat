using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float speed = 20.0f;
    private Vector2 direction = new Vector2(1, 0);
	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
