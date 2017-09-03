using UnityEngine;
using System.Collections;

public class FixToolItem : MonoBehaviour {
    public float disappearTime = 4.0f;
    private float disappearTimeTick;

    // Use this for initialization
    void Start () {
        disappearTimeTick = disappearTime;
    }
	
	// Update is called once per frame
	void Update () {

        disappearTimeTick -= Time.deltaTime;
        if (disappearTimeTick <= 0.0f)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            Destroy(gameObject);
    }
}
