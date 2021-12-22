using System.Collections;
using UnityEngine;

public class TemporaryProtection : MonoBehaviour
{
    [SerializeField] int duration;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.gameObject.GetComponent<PlayerMover>().updateIsShield();
        StartCoroutine(TemporaryProtect());
        transform.parent.gameObject.GetComponent<PlayerMover>().updateIsShield();
    }

    IEnumerator TemporaryProtect()
    {
        for (float i = 0; i < duration ; i++)
        {
            Debug.Log("Shield: " + (duration-i) + " seconds remaining!");
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Shield gone!");
        Destroy(gameObject);
    }

}
