using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuContro : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject OptionMenu;
    public GameObject TipMenu;
    public GameObject con;
    public GameObject cantCon;
    public GameObject about;
    public Slider slider;
    public Toggle toggle;
    bool HasRecord;

    public void NewGame()
    {
        MainMenu.SetActive(false);
        if (HasRecord)
            TipMenu.SetActive(true);
        else
            SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void  About()
    {
        about.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void AboutDown()
    {
        about.SetActive(false);
        MainMenu.SetActive(true);
    }
    
    public void ChooseNo()
    {
        MainMenu.SetActive(true);
        TipMenu.SetActive(false);
    }

    public void ChooseYes()
    {
        PlayerPrefs.DeleteKey("Level");
        SceneManager.LoadScene(1);
    }

    public void VolumeControl()
    {
        AudioListener.volume = slider.value;
    }

    public void mute()
    {
        if (toggle.isOn == false)
            AudioListener.pause = true;
        else
            AudioListener.pause = false;
    }

    public void Continue()
    {
        int index = PlayerPrefs.GetInt("Level", 0);
        SceneManager.LoadScene(index+1);
    }

    public void options()
    {
        MainMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void back2()
    {
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Level"))
        {
            HasRecord = true;
            con.SetActive(true);
            cantCon.SetActive(false);
        }
        else
        {
            HasRecord = false;
            con.SetActive(false);
            cantCon.SetActive(true);
        }
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
