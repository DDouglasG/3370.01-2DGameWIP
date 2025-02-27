using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    public bomb_spawner spawner;

    private void OnCollisionEnter2D(Collision2D collision) // Use Collision2D, not Trigger
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            spawner.RemoveBomb(gameObject); // Remove from spawner's list
            Destroy(gameObject); // Destroy bomb
        }
    }
}
