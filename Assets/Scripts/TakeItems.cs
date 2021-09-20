using System;
using System.Timers;
using UnityEngine;

public class TakeItems : MonoBehaviour
{
    public float TimeToTake;
    
    [SerializeField]
    private float Timer;
    private bool IsTriggering = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Timer = TimeToTake;
            IsTriggering = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsTriggering = false;
        }
    }

    private void Update()
    {
        if (IsTriggering && Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        
        else if (IsTriggering && Timer <= 0)
        {
            Take();
        }
    }

    private void Take()
    {
        Destroy(this.gameObject);
    }
}
