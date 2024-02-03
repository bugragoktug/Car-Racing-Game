using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class carController : MonoBehaviour
{
	bool currentPlatformPhone = false;
	public enemyDestroyer enemyDestroyer;
	public float carSpeed;
	Vector2 position;
	public float maxPos = 2.4f;
	private void Awake()
	{
#if UNITY_ANDROID || UNITY_IOS
		currentPlatformPhone = true;
#else
		currentPlatformPhone = false;
#endif
	}
	public GameObject backGround;
	void Start()
	{
		position = transform.position;
		if (currentPlatformPhone == true)
		{
			backGround.SetActive(false);
		}
		else
		{
			backGround.SetActive(true);
		}
	}
	public GameObject car;
	public float turnSpeed = 100f;
	private float targetZRotation = 0f;
	public void movement()
	{
		if (right == false && left == true)
		{
			position.x += ButtonSpeed * carSpeed * Time.deltaTime;
			car.transform.rotation = Quaternion.Euler(0, 0, -15);
			targetZRotation = -25f;
		}
		else if (right == true && left == false)
		{
			position.x -= ButtonSpeed * carSpeed * Time.deltaTime;
			targetZRotation = 25f;
		}
		else
		{
			right = false;
			left = false;
			targetZRotation = 0f;
		}
		float zRotation = Mathf.MoveTowardsAngle(car.transform.eulerAngles.z, targetZRotation, turnSpeed * Time.deltaTime * 3f);
		car.transform.rotation = Quaternion.Euler(0, 0, zRotation);
	}
	void Update()
	{
		position.x = Mathf.Clamp(position.x, -2.4f, 2.4f);
		transform.position = position;
		movement();
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
		right = true;
		left = false;
	}
	public void goleft()
	{
		right = false;
		left = true;
	}
	public void gitme()
	{
		right = false;
		left = false;
	}
}