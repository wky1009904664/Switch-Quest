using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    int colliderNum = 0;
    bool collBounce = false;
    public float Speed = 2;
    public float jumpHeight = 100;
    Rigidbody2D player;
    int canFly = 0;
    public float flyforce = 10;
    int faceLeft = 1;
    public static float maxSpeed = 0;
    float nowSpeed;
    AudioClip jump;
    AudioClip skill;
    AudioSource plaudio;
    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        skill = (AudioClip)Resources.Load("Music/RedF");
        jump = (AudioClip)Resources.Load("Music/Jump");
        plaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        nowSpeed = Mathf.Abs(player.velocity.y);
        if (maxSpeed < nowSpeed)
            maxSpeed = nowSpeed;
        if (Input.GetKeyDown(KeyCode.UpArrow))
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

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (canFly > 0 && colliderNum != 0 && !collBounce)
            {
                Vector2 flydire = new Vector2(2 * faceLeft, 1).normalized;
                player.AddForce(flydire * flyforce);
                --canFly;
                plaudio.clip = skill;
                plaudio.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.localScale = new Vector3(1, 1, 1) * 0.03f;
        //    transform.Translate(-Speed * Time.deltaTime, 0, 0, Space.World);
        //    
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.localScale = new Vector3(-1, 1, 1) * 0.03f;
        //    transform.Translate(Speed * Time.deltaTime, 0, 0, Space.World);
        //    faceLeft = 1;
        //}


        float h = Input.GetAxis("HorizontalRed");
        if (h < 0)
        {
            transform.localScale = new Vector3(1, 1, 1) * 0.03f;
            faceLeft = -1;
        }
        else if (h > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1) * 0.03f;
            faceLeft = 1;
        }
        transform.Translate(h * Time.deltaTime * Speed, 0, 0, Space.World);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ++colliderNum;
        if (collision.transform.tag == "RedSpring")
        {
            collBounce = true;
            return;
        }
        maxSpeed = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var tag = collision.transform.tag;
        if (tag == "Blue" & colliderNum == 1)
            return;
        if (colliderNum > 0)
            --colliderNum;
        if (tag == "RedSpring")
            collBounce = false;
    }

    public void GetRedF()
    {
        ++canFly;
    }

}
