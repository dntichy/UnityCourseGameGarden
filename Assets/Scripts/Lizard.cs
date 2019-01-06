using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Type of attacker
/// </summary>
public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        //has defender obj?  -> call attack
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }

    }
}
