using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
        // The force at which this crate will push the collided object.
    public float pushForce = 4f;

  
    
    /// <summary>
    /// Triggers when this collider overlaps with another.
    /// </summary>
    /// <param name="collision">The other collider.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // attachedRigidbody returns the Rigidbody component the collider belongs to.
        if (collision.attachedRigidbody != null)
        {
            // Will give back a +1 or -1 depending on the player's position relative to the crate.
            float direction = Mathf.Sign(collision.attachedRigidbody.position.y - transform.position.y);

            // Will push the player up if the player is above the crate.
            if (direction > 0)
            {
                Vector2 velocity = collision.attachedRigidbody.velocity;
                velocity.y = pushForce;
                collision.attachedRigidbody.velocity = velocity;
            }

            Break();
        }
    }


    public void Break()
    {
        // TODO: Unparent all children.
        while (transform.childCount > 0)
        {
           
            Transform t = transform.GetChild(0);
            t.SetParent(null);
            t.gameObject.SetActive(true);
            
        }
       

        Destroy(gameObject);
    }
}
