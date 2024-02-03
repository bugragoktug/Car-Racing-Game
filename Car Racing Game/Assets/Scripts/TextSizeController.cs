using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeController : MonoBehaviour
{
    public TMP_Text text;  // Unity sahnesindeki Text bileşenini bu değişkene sürükleyin

    public float maxSize = 30f;  // Yazının maksimum büyüklüğü
    public float minSize = 10f;  // Yazının minimum büyüklüğü
    public float speed = 1f;     // Büyüme/küçülme hızı

    private void Update()
    {
        float newSize = Mathf.Lerp(minSize, maxSize, Mathf.PingPong(Time.time * speed, 1f));
        text.fontSize = (int)newSize;
    }
}