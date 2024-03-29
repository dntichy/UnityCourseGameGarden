﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// If defender is shooter,spefify, projectile, Gun
/// </summary>
public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLineSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            //Debug.Log("shoot");
            //change animation state -> shooting
            animator.SetBool("isAttacking", true);

        }
        else
        {
            //Debug.Log("sit and wait");
            //change animation state -> idle
            animator.SetBool("isAttacking", false);
        }
    }


    private void SetLineSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
    /// <summary>
    /// Check if attacker is on Lane
    /// </summary>
    /// <returns></returns>
    private bool IsAttackerInLane()
    {
        //if lanespawner child count is <= 0  -> return false;
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Fires Projectile
    /// </summary>
    public void Fire()
    {

        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
