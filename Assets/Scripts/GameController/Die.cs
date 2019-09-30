using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject death;
    AudioSource plaudio;
    AudioClip die;
    // Start is called before the first frame update
    void Start()
    {
        plaudio = GetComponent<AudioSource>();
        die = (AudioClip)Resources.Load("Music/Die");
        plaudio.clip = die;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Blue" || collision.transform.tag == "Red")
            Died();
        else
            Destroy(collision.gameObject);
    }

    void Died()
    {
        death.SetActive(true);
        Time.timeScale = 0;
        PauseMenu.canPasue = false;
        plaudio.Play();
    }
}
