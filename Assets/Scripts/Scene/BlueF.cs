using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueF : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blue")
        {
            collision.GetComponent<Blue>().GetBlueF();
            Destroy(this.gameObject);
        }
    }
}
