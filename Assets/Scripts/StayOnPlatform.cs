using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;
    private bool moving;

    //public bool WasWithPlayer;

  

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {

            other.gameObject.GetComponent<HorizontalPlatform>();
            other.gameObject.GetComponent<VerticalPlatform>();
            other.gameObject.GetComponent<RotatingPlatform>();
            transform.SetParent(other.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.collider.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }
}
