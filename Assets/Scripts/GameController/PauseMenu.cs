using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject Menu;
    public Slider slider;
    public static bool canPasue = true;

    public void OnPause() {
        Time.timeScale = 0;
        if (canPasue)
            Menu.SetActive(true);
    }

    public void OnContinue()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void VolumeControl()
    {
        AudioListener.volume = slider.value;
    }

    public void quit()
    {
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
     
        
    }
}
