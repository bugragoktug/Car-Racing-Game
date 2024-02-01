using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class carSpawner : MonoBehaviour
{
    public GameObject[] cars;
    public float maxPos = 2.4f;
    int carNo;
    public float delayTimer;
    float timer;
    void Start()
    {
        timer = delayTimer;
    }
    void Update()
    {
		timer -= Time.deltaTime;
        if (timer <= 0)
        {
			Vector3 carPos = new Vector3(Random.Range(-2.4f, 2.4f), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 5);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTimer;
		}
	}
}
