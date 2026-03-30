using UnityEngine;

public class detectCollider : MonoBehaviour
{
   
    // This function is called when another collider enters the trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Log a message to the console for demonstration

        if (other.name == "arteries")
        {
            Debug.Log("Those arteries have some slices in them...");
        }
        if (other.name == "heart")
        {
            Debug.Log("It appears his heart was broken...");
        }
        Debug.Log("Trigger Entered by: " + other);
        
        // You can add specific logic here, e.g., if (other.CompareTag("Player")) { /* do something */ }
    }

    // This function is called once per frame for every collider touching the trigger
    void OnTriggerStay2D(Collider2D other)
    {
       
    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exited by: " + other.gameObject.name);
    }
}

