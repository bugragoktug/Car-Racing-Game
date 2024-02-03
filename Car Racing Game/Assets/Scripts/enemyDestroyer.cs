using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D;
public class enemyDestroyer : MonoBehaviour
{
	public Button[] buttons;
	public Button[] but2;
	bool gameOver;
	public Text scoreText, highscoretext; 
	int score;
	private void Start()
	{
		gameOver = false;
		highscoretext.text = "High Score: " + PlayerPrefs.GetInt("score").ToString();
	}
	private void Update()
	{
		scoreText.text = "Score: " + score;
	}
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			Destroy(col.gameObject);
			if (gameOver == false)
			{
				score++;
			}
		}
	}
	public void IsGameOver()
	{
		if (PlayerPrefs.GetInt("score") < score)
		{
			PlayerPrefs.SetInt("score", score);
		}	
		gameOver = true;
		foreach (Button button in buttons)
		{
			button.gameObject.SetActive(true);
		}

		foreach (Button button in but2)
		{
			button.gameObject.SetActive(false);
		}
		Time.timeScale = 0;
	}
}
