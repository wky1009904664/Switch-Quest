using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    int colliderNum = 0;
    bool collBounce = false;
    public float Speed = 2;
    public float jumpHeight = 100;
    Rigidbody2D player;
    Transform Red;
    int canPlank = 0;
    GameObject plank;
    public static float maxSpeed = 0;
    float nowSpeed;
    AudioSource plaudio;
    AudioClip jump;
   
    AudioClip skill;
    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        Red = GameObject.FindWithTag("Red").transform;
        plank = (GameObject)Resources.Load("Prefabs/Plank");
        plaudio = GetComponent<AudioSource>();
        skill =(AudioClip) Resources.Load("Music/BlueF");
        jump = (AudioClip)Resources.Load("Music/Jump");
       

    }

    // Update is called once per frame
    void Update()
    {
        nowSpeed = Mathf.Abs(player.velocity.y);
        if (maxSpeed < nowSpeed)
            maxSpeed = nowSpeed;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (colliderNum != 0 && !collBounce)
            {
                maxSpeed = 0;
                Vector2 force = new Vector2(0, jumpHeight);
                player.AddForce(force);
                colliderNum = 0;
                plaudio.clip = jump;
                plaudio.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canPlank > 0)
            {
                Instantiate(plank, transform.position - new Vector3(0, 0.3f, 0), Quaternion.identity);
                --canPlank;
                plaudio.clip = skill;
                plaudio.Play();
            }
        }
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxis("HorizontalBlue");
        if (h < 0)
            transform.localScale = new Vector3(1, 1, 1) * 0.03f;
        else if (h > 0)
            transform.localScale = new Vector3(-1, 1, 1) * 0.03f;
        transform.Translate(h * Time.deltaTime * Speed, 0, 0, Space.World);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ++colliderNum;
        if (collision.transform.tag == "BlueSpring")
        {
            collBounce = true;
            return;
        }
        maxSpeed = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var tag = collision.transform.tag;
        if (tag == "Red" & colliderNum == 1)
            return;
        if (colliderNum > 0)
            --colliderNum;
        if (tag == "BlueSpring")
            collBounce = false;
    }

    public void GetBlueF()
    {
        ++canPlank;

    }
}
