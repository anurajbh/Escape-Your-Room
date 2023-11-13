using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //central animation controller
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
