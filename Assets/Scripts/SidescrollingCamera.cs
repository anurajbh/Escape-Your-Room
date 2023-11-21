using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollingCamera : MonoSingleton<SidescrollingCamera>
{
    public Vector3 offset;
    private void LateUpdate()
    {
        transform.position = PlayerCharacter.Instance.transform.position + offset;
    }
}
