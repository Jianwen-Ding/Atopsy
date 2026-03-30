using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TextLoader : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        infoText.text = "Drop Organs Below";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
