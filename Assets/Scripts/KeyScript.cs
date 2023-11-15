using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyScript : MonoBehaviour
{
    [SerializeField] KeysCollected keyCollector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            keyCollector.AddKey();
           
            Destroy(gameObject);
        }
     
    }
}
