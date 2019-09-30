using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBounce : MonoBehaviour
{
    Transform other;
    Rigidbody2D blue;
    Vector2 speed;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        other = collision.transform;
        if (other.tag == "Blue")
        {
         blue = other.GetComponent<Rigidbody2D>();
            blue.velocity = new Vector2(0, Blue.maxSpeed);
            Blue.maxSpeed = 0;
            audio.Play();
        }
        
    }
}
