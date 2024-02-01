using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class carController : MonoBehaviour
{
	bool currentPlatformAndroid = false;
	public enemyDestroyer enemyDestroyer;
	public float carSpeed;
	Vector2 position;
	public float maxPos = 2.4f;
	private void Awake()
	{
#if UNITY_ANDROID
		currentPlatformAndroid = true;
#else
		currentPlatformAndroid = false;
#endif
	}
	void Start()
	{
		position = transform.position;
		if (currentPlatformAndroid == true)
		{

		}
	}
	void Update()
	{
		position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
		position.x = Mathf.Clamp(position.x, -2.4f, 2.4f);
		transform.position = position;
		if (right == false && left == true)
		{
			position.x += ButtonSpeed * carSpeed * Time.deltaTime;
		}
		else if (right == true && left == false)
		{
			position.x -= ButtonSpeed * carSpeed * Time.deltaTime;
		}
		else
		{
			right = false;
			left = false;
}
	}
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
			enemyDestroyer.IsGameOver();
		}
	}
	public float ButtonSpeed;
	private bool right = false;
	private bool left = false;
	public void goright()
	{
		//position.x += ButtonSpeed * carSpeed * Time.deltaTime;
		right = true;
		left = false;
}
	public void goleft()
	{
		//position.x -= ButtonSpeed * carSpeed * Time.deltaTime;
		right = false;
		left = true;
	}
	public void gitme()
	{
		right = false;
		left = false;
}
}