using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    [SerializeField] private ControlJugador player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ladder>())
        {
            Debug.Log("Climbing allowed!");
            player.ClimbingAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Ladder>())
        {
            player.ClimbingAllowed = false;
        }
    }
}