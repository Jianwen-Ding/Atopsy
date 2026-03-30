

using UnityEngine;
using UnityEngine.EventSystems;

public class DragRigidBody : MonoBehaviour {
    //[SerializedField] private Canvas canvas;
    private RectTransform rectTransform;
    private Camera camera;
    private Rigidbody2D rb;
    private Vector2 offset;
    private bool dragging = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        //Debug.Log("mouse down");
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        offset = rb.position - mousePos;
        dragging = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void OnMouseUp()
    {
        //Debug.Log("mouse up");
        dragging = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       if (dragging)
        {
            Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(mousePos + offset);
        }
    }

    
    
}
