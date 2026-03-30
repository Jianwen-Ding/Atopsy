using UnityEngine;

public class canvasVisible : MonoBehaviour
{
   
    public GameObject canvas;
    private bool visibility = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        canvas.SetActive(visibility);
        if (Input.GetKeyDown(KeyCode.E))
        {
            visibility = !visibility;
        }
    }
}
