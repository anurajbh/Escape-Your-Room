using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatBox : MonoBehaviour
{
    //timer to prevent life decrementation from stacking when player falls back into trigger collider almost immediately after leaving it
    [SerializeField] float decrementTimer = 0f;
    //bool to lock or unlock the life decrementation
    bool canDecrement = true;
    private void Start()
    {
        canDecrement = false;
        StartCoroutine(DecrementBeginningTimer());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && canDecrement)
        {
            //make the player lie down when entering bed trigger and start coroutine to decrement lives
            GameManager.Instance.animator.SetBool("isLyingDown", true);
            StartCoroutine(DecrementLiveCoroutine());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //ensure the player continues to lie down when within bed trigger
            GameManager.Instance.animator.SetBool("isLyingDown", true);
        }
    }
    IEnumerator DecrementLiveCoroutine()
    {
        canDecrement = false;
        Debug.Log("Decrementing Life");
        PlayerCharacter.Instance.DecrementLives();
        PlayerCharacter.Instance.CheckForLoss();
        //wait decrementTimer number of seconds before re-enabling canDecrement
        yield return new WaitForSeconds(decrementTimer);
        canDecrement = true;

    }
    IEnumerator StartDecrementTimer()
    {
        yield return new WaitForSeconds(decrementTimer);
        canDecrement = true;
    }    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //make player get up on leaving bed trigger
            GameManager.Instance.animator.SetBool("isLyingDown", false);
            canDecrement = false;
            StartCoroutine(StartDecrementTimer());
        }
    }
    IEnumerator DecrementBeginningTimer()
    {
        yield return new WaitForSeconds(decrementTimer);
        canDecrement = true;
    }
}
