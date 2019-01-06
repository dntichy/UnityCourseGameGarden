using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The one who attacks our Garden
/// </summary>
public class Attacker : MonoBehaviour
{

    [Range(0f, 5f)] float currentSpeed = 1f; //speed of the attacker
    GameObject currentTarget; //target currently being attacked by attacker


    //very first method that executes
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null) levelController.AttackerKilled();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState(); //update animation, so attacker continues walking
    }

    /// <summary>
    /// Updates animation state
    /// </summary>
    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    /// <summary>
    /// Sets movement speed of Attacker
    /// </summary>
    /// <param name="speed"></param>
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    /// <summary>
    /// Sets object to attack, also changes animation state to attacking
    /// </summary>
    /// <param name="target"></param>
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }
    /// <summary>
    /// Strikes target if exists
    /// </summary>
    /// <param name="damage"></param>
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damage);
        }

    }
}

