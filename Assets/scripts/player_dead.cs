using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_dead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bomb_enemy"))
        {
            Debug.Log("player Hit! Game Over.");
            Destroy(gameObject);
        }
        
        
    }
}
