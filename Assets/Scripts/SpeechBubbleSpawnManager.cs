using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleSpawnManager : MonoSingleton<SpeechBubbleSpawnManager>
{
    public List<GameObject> speechBubblePrefabList = new List<GameObject>();
    public int tierOneCount;
    public float spawnInterval = 2f;
    public Vector2 spawnPositionOffset;

    [SerializeField] float spawnTimer = 0f;
    [SerializeField] int randomIndex = 0;
    public int maxIndex = 0;

    private void Start()
    {
        //no need to decrement by one as random.range is exclusive of max value
        maxIndex = tierOneCount;
        SetMaxIndexToSpawn(maxIndex);
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
            SetMaxIndexToSpawn(maxIndex);
            SpawnTheBubbleAtIndex(randomIndex);
        }
    }
    public void SetMaxIndexToSpawn(int MaxToSpawn)
    {
        maxIndex = MaxToSpawn;
        randomIndex = Mathf.Clamp(Random.Range(0, MaxToSpawn), 0, MaxToSpawn);
    }    
    private void SpawnTheBubbleAtIndex(int indexToSpawn)
    {
        if(maxIndex == 0)
        {
            return;
        }
        // Instantiate a new speech bubble at the spawn position controlled by spawn position offset
        Vector3 spawnPosition = PlayerCharacter.Instance.transform.position + new Vector3(Random.Range(spawnPositionOffset.x / 2f, spawnPositionOffset.x), Random.Range(spawnPositionOffset.y / 2f, spawnPositionOffset.y), 0f);
        Instantiate(speechBubblePrefabList[indexToSpawn], spawnPosition, Quaternion.identity);
    }
}
