using UnityEngine;

public class Spawner : MonoBehaviour
{

    #region Fields
    public float spawnTime = 5f;		// The amount of time between each spawn.
    public float spawnDelay = 3f;		// The amount of time before spawning starts.
    public GameObject[] zombies;		// Array of enemy prefabs.
    #endregion

    #region Start
    void Start () {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
    #endregion

    #region Update is called once per frame
    void Spawn ()
	{

		if( !globalVars.isGameActive ) return;
        // Instantiate a random enemy.
        var enemyIndex = Random.Range(0, zombies.Length);
        Instantiate(zombies[enemyIndex], transform.position, transform.rotation);

        // Play the spawning effect from all of the particle systems.
        /*foreach (var p in GetComponentsInChildren<ParticleSystem>())
        {
            p.Play();
        }*/
    }
    #endregion

}
