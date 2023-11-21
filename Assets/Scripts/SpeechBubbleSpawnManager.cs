using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleSpawnManager : MonoSingleton<SpeechBubbleSpawnManager>
{
    public List<GameObject> speechBubblePrefab = new List<GameObject>();
    public float spawnInterval = 2f;
    public Vector2 spawnPositionOffset;

    [SerializeField] float spawnTimer = 0f;
    [SerializeField] int randomIndex = 0;

    private void Start()
    {
        Vector3 spawnPosition = PlayerCharacter.Instance.transform.position + new Vector3(Random.Range(spawnPositionOffset.x / 2f, spawnPositionOffset.x), Random.Range(spawnPositionOffset.y / 2f, spawnPositionOffset.y), 0f);
        randomIndex = Random.Range(0, speechBubblePrefab.Count);
        Instantiate(speechBubblePrefab[randomIndex], spawnPosition, Quaternion.identity);
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
            Vector3 spawnPosition = PlayerCharacter.Instance.transform.position+ new Vector3(Random.Range(spawnPositionOffset.x/2f, spawnPositionOffset.x), Random.Range(spawnPositionOffset.y / 2f, spawnPositionOffset.y), 0f);
            randomIndex = Mathf.Clamp(Random.Range(0, speechBubblePrefab.Count - 1), 0, speechBubblePrefab.Count - 1);
            Instantiate(speechBubblePrefab[randomIndex], spawnPosition, Quaternion.identity);
        }
    }
}
