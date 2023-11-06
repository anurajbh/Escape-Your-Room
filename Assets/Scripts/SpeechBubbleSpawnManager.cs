using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleSpawnManager : MonoSingleton<SpeechBubbleSpawnManager>
{
    public GameObject speechBubblePrefab;
    public float spawnInterval = 2f;
    public Vector2 spawnPositionOffset;

    [SerializeField] float spawnTimer = 0f;

    private void Start()
    {
        Vector3 spawnPosition = PlayerCharacter.Instance.transform.position + new Vector3(Random.Range(0, spawnPositionOffset.x), Random.Range(0, spawnPositionOffset.y), 0f);
        Instantiate(speechBubblePrefab, spawnPosition, Quaternion.identity);
    }
    private void Update()
    {
        // Increase the spawn timer
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn a new speech bubble
        if (spawnTimer >= spawnInterval)
        {
            // Reset the spawn timer
            spawnTimer = 0f;

            // Instantiate a new speech bubble at the spawn position controlled by spawn position offset
            Vector3 spawnPosition = PlayerCharacter.Instance.transform.position+ new Vector3(Random.Range(0, spawnPositionOffset.x), Random.Range(0, spawnPositionOffset.y), 0f);
            Instantiate(speechBubblePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
