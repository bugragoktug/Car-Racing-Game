using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class uiMananger : MonoBehaviour
{
    void Start()
    {
		int width = 900; // Genişliği belirle
		int height = 1600; // Genişlik ile orantılı yüksekliği hesapla (9:16)
		bool isFullScreen = false; // Tam ekran modu kapalı
		Screen.SetResolution(width, height, isFullScreen);// Oyun başladığında belirtilen çözünürlüğü ayarla
	}
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
			AudioListener.pause = true; ;
		}
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
			AudioListener.pause = false;
		}
    }
    public void Play()
    {
        Application.LoadLevel("audi");
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
