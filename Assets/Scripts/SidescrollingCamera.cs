using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollingCamera : MonoSingleton<SidescrollingCamera>
{
    public float offset;
    public bool followPlayer = false;
    private void LateUpdate()
    {
        if (followPlayer)
        {
            transform.position = new Vector3(PlayerCharacter.Instance.transform.position.x + offset, transform.position.y, transform.position.z);
        }
    }
}
 