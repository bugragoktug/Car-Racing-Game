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
		//position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
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
		//position.x += ButtonSpeed * carSpeed * Time.deltaTime;
		right = true;
		left = false;
		//car.transform.rotation = Quaternion.Euler(0, 0, 15);
	}
	public void goleft()
	{
		//position.x -= ButtonSpeed * carSpeed * Time.deltaTime;
		right = false;
		left = true;
		//car.transform.rotation = Quaternion.Euler(0, 0, -15);
	}
	public void gitme()
	{
		right = false;
		left = false;
}
}