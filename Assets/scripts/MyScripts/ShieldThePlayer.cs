using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Shield triggered.");
        if (other.tag == "Player")
        {
            GameObject shield = Instantiate(prefabToSpawn, other.gameObject.transform.position, Quaternion.identity);
            shield.transform.parent = other.gameObject.transform;
            Destroy(gameObject);  // Destroy the shield itself - prevent double-use 
        }
    }
}
