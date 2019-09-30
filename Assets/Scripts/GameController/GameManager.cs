using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Transform Blue;
    Transform Red;
    int countB = 0;
    int countR = 0;
    int countC = 0;
    bool startCountB = false;
    bool startCountR = false;
    bool changeBig = false;
    GameObject bgm;
    int index;
    GameObject obj = null;
    AudioClip RightClip;
    public static bool Bluein = false;
    public static bool Redin = false;
    AudioSource audios;
    AudioSource Switch;
    AudioClip sw;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.canPasue = true;  
        Time.timeScale = 1;
        index = SceneManager.GetActiveScene().buildIndex;
        Blue = GameObject.FindWithTag("Blue").transform;
        Red = GameObject.FindWithTag("Red").transform;
        Switch = GetComponent<AudioSource>();
        sw = (AudioClip)Resources.Load("Music/Switch");
        Switch.clip = sw;
        if (index <= 4)
            RightClip = (AudioClip)Resources.Load("Music/bgm1");
        else if (index <= 8)
            RightClip = (AudioClip)Resources.Load("Music/bgm2");
        else if (index <= 11)
            RightClip = (AudioClip)Resources.Load("Music/bgm3");
        else if (index <= 14)
            RightClip = (AudioClip)Resources.Load("Music/bgm4");

        bgm =(GameObject) Resources.Load("Prefabs/BGM");
        obj = GameObject.FindGameObjectWithTag("Sound");
        if (obj == null)
        {
            obj = Instantiate(bgm);
        }
        audios = obj.GetComponent<AudioSource>();
        if (audios.clip != RightClip)
        {
            audios.clip = RightClip;
            audios.Play();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Redin = false;
            Bluein = false;
            Reload();
        }     

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (startCountR)
            {
                ChangePos();
                Reset();
                countC = 0;
                changeBig = true;
            }
            else
            {
                startCountB = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (startCountB)
            {
                ChangePos();
                Reset();
                countC = 0;
                changeBig = true;
            }
            else
            {
                startCountR = true;
            }
        }

        if (startCountB)
        {
            if (countB <= 6)
            {
                float cc = 1 - (float)countB / 10;
                Blue.localScale = new Vector3(cc, cc, cc) * 0.03f;
            }
            else
            {
                float cc = (float)countB / 10 - 0.2f;
                Blue.localScale = new Vector3(cc, cc, cc) * 0.03f;
            }
            countB++;
            if (countB >= 12)
            {
                Blue.transform.position = Red.position + new Vector3(0, 0.3f, 0);
                countB = 0;
                startCountB = false;
                Blue.localScale = new Vector3(1, 1, 1) * 0.03f;
                Switch.Play();
            }
        }

        if (startCountR)
        {
            float cc = 1 - (float)countR / 10;
            Red.localScale = new Vector3(cc, cc, cc) * 0.03f;
            countR++;
            if (countR >= 12)
            {
                Red.transform.position = Blue.position + new Vector3(0, 0.3f, 0);
                countR = 0;
                startCountR = false;
                Red.localScale = new Vector3(1, 1, 1) * 0.03f;
                Switch.Play();
            }
        }

        if (changeBig)
        {
            countC++;
            if (countC <= 6)
            {
                float cc = 1 - (float)countC / 10;
                Blue.localScale = new Vector3(cc, cc, cc) * 0.03f;
                Red.localScale = new Vector3(cc, cc, cc) * 0.03f;
            }
            else if (countC <= 12)
            {
                float cc = (float)countC / 10 - 0.2f;
                Blue.localScale = new Vector3(cc, cc, cc) * 0.03f;
                Red.localScale = new Vector3(cc, cc, cc) * 0.03f;
            }
            else
            {
                Red.localScale = new Vector3(1, 1, 1) * 0.03f;
                Blue.localScale = new Vector3(1, 1, 1) * 0.03f;
                countC = 0;
                changeBig = false;
            }
        }

    }

    private void Reset()
    {
        countB = 0;
        countR = 0;
        startCountB = false;
        startCountR = false;
        //  Blue.localScale = new Vector3(1, 1, 1);
        //  Red.localScale = new Vector3(1, 1, 1);
    }

    void ChangePos()
    {
        Vector3 temp = Blue.position;
        Blue.position = Red.position;
        Red.position = temp;
        Switch.Play();
    }

    public static void NextRoom()
    {
        if (Bluein && Redin)
        {
            Bluein = false;
            Redin = false;
            int index = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("Level", index);
            SceneManager.LoadScene(index + 1);
        }
    }

    void Reload()
    {
       
        SceneManager.LoadScene(index);
    }

}
