using UnityEngine;
using TMPro;
using System.Collections; // Required for Coroutines

public class TextLoader : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public GameObject receiver; 
    public float typingSpeed = 0.05f;

    void Start()
    {
        infoText.text = "";
        StartCoroutine(TypeText("Drop Organs Below..."));
    }

    void Update()
    {
        TypeText(GetMsg());
    }

    IEnumerator TypeText(string message)
    {
        infoText.text = ""; 
        foreach (char c in message)
        {
            infoText.text += c; // Add one character at a time
            yield return new WaitForSeconds(typingSpeed); // Wait a tiny bit
        }
    }
}