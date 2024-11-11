using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollingCamera : MonoSingleton<SidescrollingCamera>
{
    public float offset;
    public bool followPlayer = false;
    public float smoothSpeed = 0.125f; // Adjust this to control smoothing
    public float threshold = 0.5f;

    Vector3 lastPlayerPosition;
    void FixedUpdate()
    {
        if (followPlayer)
        {
            Vector3 playerPosition = PlayerCharacter.Instance.transform.position;
            // Only update if player has moved beyond the threshold distance
            if (Mathf.Abs(playerPosition.x - lastPlayerPosition.x) > threshold)
            {
                Vector3 targetPosition = new Vector3(playerPosition.x + offset, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
                lastPlayerPosition = playerPosition; // Update last known player position
            }
        }
    }
}
 