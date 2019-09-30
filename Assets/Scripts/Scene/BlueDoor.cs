using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Blue")
            GameManager.Bluein = true;
        GameManager.NextRoom();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Blue")
            GameManager.Bluein = false;
    }
}
