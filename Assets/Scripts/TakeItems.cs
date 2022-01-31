using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItems : MonoBehaviour
{
    public float TimeToTake = 5;
    public Image ImgTimer;
    private float TakeTimer;

    public float RoundTime = 600;
    public Text RoundTimer;
    private float RoundTimeCounting;
    public float WrongValue = 50;

    private GameObject Enemy;
    public GameObject PoadingbarPoint;
    
    public float DistanceBetweenTakenObjects;

    [SerializeField]
    private List<GameObject> TakenObjects;
    public Text CountTaken;

    private Sprite podiumSprite;

    public Podium podium;

    private void Start()
    {
        ImgTimer.fillAmount = 0;
        RoundTimeCounting = RoundTime;

        RoundTimer.text = RoundTimeCounting.ToString("f0");
        CountTaken.text = TakenObjects.Count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !Enemy)
        {
            Enemy = other.gameObject;
            TakeTimer = TimeToTake;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == Enemy)
        {
            Enemy = null;
            ImgTimer.fillAmount = 0;
        }
    }

    private void Update()
    {
        if (RoundTimeCounting > 0)
        {
            RoundTimeCounting -= Time.deltaTime;

            RoundTimer.text = RoundTimeCounting.ToString("f0");
        }

        else
        {
            Loose();
        }

        if (Enemy && TakeTimer > 0 && !TakenObjects.Contains(Enemy))
        {
            TakeTimer -= Time.deltaTime;

            ImgTimer.fillAmount = TakeTimer / TimeToTake;
        }
        
        else if (Enemy && TakeTimer <= 0 && !TakenObjects.Contains(Enemy))
        {
            if (Enemy.GetComponent<SpriteRenderer>().sprite == podiumSprite)
            {
                Take();
                podium.SwitchSprite();
            }

            else
            {
                print(Enemy.GetComponent<SpriteRenderer>().sprite + " | " + podiumSprite.name);
                Wrong();
            }
        }
    }

    private void Wrong()
    {
        print("Wrong");
        RoundTimeCounting -= WrongValue;
        Enemy = null;
        ImgTimer.fillAmount = 0;
    }

    private void Loose()
    {
        print("Loooooooooser");
    }

    private void Take()
    {
        TakenObjects.Add(Enemy);
        
        Enemy.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
        
        Enemy.transform.position = PoadingbarPoint.transform.position;
        PoadingbarPoint.transform.position += new Vector3(DistanceBetweenTakenObjects, 0, 0);

        CountTaken.text = TakenObjects.Count.ToString();
    }

    public void SwitchPodiumSprite(Sprite newPodiumSprite)
    {
        podiumSprite = newPodiumSprite;
    }
}
