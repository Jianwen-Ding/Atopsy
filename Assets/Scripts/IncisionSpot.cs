using UnityEngine;

public class IncisionSpot : MonoBehaviour
{
    
    [SerializeField] GameObject incisionOpening;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        incisionOpening.SetActive(true);
    }

    private void OnMouseDown()
    {
        incisionOpening.SetActive(false);
        Destroy(this);
    }
}
