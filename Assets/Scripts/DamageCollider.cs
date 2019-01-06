using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is collider that represents area behind the defenders.
/// On triggerEnter Shold Take life of Player
/// </summary>
public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        FindObjectOfType<LivesDisplay>().TakeLive();
        Destroy(otherCollider.gameObject);

    }
}
