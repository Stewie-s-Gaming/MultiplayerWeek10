using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 10f;
    [Tooltip("Maximum distance in Y between spawner and spawned objects, in meters")] [SerializeField] float maxYDistance = 10f;
    GameObject myPrefab;
    GameObject player;
    private void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            myPrefab = GameObject.Find("Shield(Clone)");
            player = GameObject.Find("PlayerSpaceship");
            if (myPrefab == null)
            {
                Debug.Log("Shield created!");
                float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
                yield return new WaitForSeconds(timeBetweenSpawns);
                Vector3 positionOfSpawnedObject = new Vector3(
                    transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                    transform.position.y,
                    transform.position.z + Random.Range(-maxYDistance, +maxYDistance));
                GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, Quaternion.identity);
            }
            if (myPrefab != null)
            {
                yield return new WaitUntil(() => (GameObject.Find("ShieldOn(Clone)")==null && ( myPrefab = GameObject.Find("Shield(Clone)") )==null));
            }

        }
    }
}
