using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents Healt of an Elements - Defenders or Attackers
/// </summary>
public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f; //health of object
    [SerializeField] GameObject deathVFX; //animation to play when destroyed

    /// <summary>
    /// Deals damage to an object
    /// </summary>
    /// <param name="damage"></param>
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            //if Attacker is Destroyed, then add statistics of Killed creatures
            if (GetComponents<Attacker>() != null)
            {
                if (gameObject.GetComponentInParent<Attacker>() != null)
                {
                    PlayerStats.KilledCreatures++;
                    Debug.Log(PlayerStats.KilledCreatures);
                }
            }
            Destroy(gameObject); 

        }
    }

    /// <summary>
    /// Triggers Destroy animation
    /// </summary>
    private void TriggerDeathVFX()
    {
        if (!deathVFX) return;
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);

    }
}
