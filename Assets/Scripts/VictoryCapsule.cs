using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VictoryCapsule : MonoBehaviour
{
    [SerializeField] GameObject victoryPanel;
    private void Start()
    {
        victoryPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            victoryPanel.SetActive(true);
            //pause the game
            Time.timeScale = 0.0f;
        }
    }
}
