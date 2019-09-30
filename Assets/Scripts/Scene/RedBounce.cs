using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBounce : MonoBehaviour
{
    Transform other;
    Rigidbody2D red;
    Vector2 speed;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        red = GameObject.FindWithTag("Red").GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        other = collision.transform;
        if (other.tag == "Red")
        {
            if (Mathf.Abs(red.velocity.x) > 0.2)
                red.velocity = new Vector2(red.velocity.x, Red.maxSpeed);

            else
                red.velocity = new Vector2(0, Red.maxSpeed);
            Red.maxSpeed = 0;
            audio.Play();
        }
        else if (other.tag == "RedSpring")
        {
            var t = other.GetComponent<Rigidbody2D>();
            t.velocity = new Vector2(t.velocity.x, -t.velocity.y);
        }
    }

   
}
