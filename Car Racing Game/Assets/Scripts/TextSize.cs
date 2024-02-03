using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
public class TextSize : MonoBehaviour
{
	public TMP_Text text;  // Unity sahnesindeki Text bileşenini bu değişkene sürükleyin
	public float maxSize = 30f;  // Yazının maksimum büyüklüğü
	public float minSize = 10f;  // Yazının minimum büyüklüğü
	public float speed = 1f;     // Büyüme/küçülme hızı
	void Update()
    {
		float newSize = Mathf.Lerp(minSize, maxSize, Mathf.PingPong(Time.time * speed, 1f));
		text.fontSize = (int)newSize;
	}
}
