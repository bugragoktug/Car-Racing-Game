using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class uiMananger : MonoBehaviour
{
    //float score;
    //public Text scoreText;
    
    void Start()
    {
        //score = 0;
    }
    void Update()
    {
        //scoreText.text = "Score:" + score;

    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void Play()
    {
        Application.LoadLevel("SampleScene");
    }
    public void Quit()
    {
        Application.Quit(); 
	}
    public void menu()
    {
		SceneManager.LoadScene("menuScene");
		Time.timeScale = 1;
	}
	public void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1;

	}
    bool isMuted = false;
    public void soundOnOff()
    {
        if (isMuted == false)
        {
            AudioListener.pause = true;
            isMuted=true;
		}
        else if ( isMuted == true) {
			AudioListener.pause = false;
			isMuted = false ;
		}

	}



}
