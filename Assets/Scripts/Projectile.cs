using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Projectile of Defender. Can be added to Defender
/// </summary>
public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50;

    /// <summary>
    /// Move object on update toweards attacker
    /// </summary>
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        //Debug.Log("I hit " + otherCollider.name);

    }
}
