using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attacker spawner represnts What attackers to spawn and with what delays
/// </summary>
public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true; //determines if should spawn
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float minSpawnDelay = 1f; 
    [SerializeField] Attacker[] attackerPrefabArray; //attackers in spawner


    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
    /// <summary>
    /// Stops spawning 
    /// </summary>
    public void StopSpawning()
    {
        spawn = false;
    }
    /// <summary>
    /// Spawns attacker to a lane
    /// </summary>
    /// <param name="myAttacker"></param>
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
    /// <summary>
    /// Spawns attacker, randomly according to attackerIndex
    /// </summary>
    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }
}
