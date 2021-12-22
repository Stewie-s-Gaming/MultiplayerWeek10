using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreUpdater : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    [SerializeField] GameObject parent;
    int scoring;
    private void Start()
    {
        scoring = 10;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggeringTag && !checkForShield(other.gameObject))
        {
           parent.GetComponentInChildren<scoreCounter>().updateScore(scoring);
        }
    }
    public bool checkForShield(GameObject gameObject)
    {
        return gameObject.GetComponent<PlayerMover>().isProtected();
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == triggeringTag && !checkForShield(other.gameObject))
        {
            parent.GetComponentInChildren<scoreCounter>().updateScore(scoring);
        }
    }
}
