using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItems : MonoBehaviour
{
    public float TimeToTake = 5;
    public Image ImgTimer;
    
    private float Timer;

    private GameObject Enemy;
    public GameObject PoadingbarPoint;
    
    public float DistanceBetweenTakenObjects;

    [SerializeField]
    private List<GameObject> TakenObjects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy = other.gameObject;
            Timer = TimeToTake;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy = null;
            ImgTimer.fillAmount = 0;
        }
    }

    private void Start()
    {
        ImgTimer.fillAmount = 0;
    }

    private void Update()
    {
        if (Enemy && Timer > 0)
        {
            Timer -= Time.deltaTime;

            ImgTimer.fillAmount = Timer / TimeToTake;
        }
        
        else if (Enemy && Timer <= 0)
        {
            if (!TakenObjects.Contains(Enemy))
            {
                Take();
            }
        }
    }

    private void Take()
    {
        TakenObjects.Add(Enemy);
        
        Enemy.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
        
        Enemy.transform.position = PoadingbarPoint.transform.position;
        PoadingbarPoint.transform.position += new Vector3(DistanceBetweenTakenObjects, 0, 0);
    }
}
