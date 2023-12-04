using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int maxIndex = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        SpeechBubbleSpawnManager.Instance.SetMaxIndexToSpawn(maxIndex);
        Destroy(gameObject);
    }
}
