using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //central animation controller
    public Animator animator;
    public GameObject _currentBackground;
    void Start()
    {
        animator = GetComponent<Animator>();
        _currentBackground = GameObject.Find("Background");
    }
}
