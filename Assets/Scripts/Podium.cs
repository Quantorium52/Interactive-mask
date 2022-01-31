using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Podium : MonoBehaviour
{
    public SpriteRenderer PodiumEnemy;
    public Sprite[] EnemieSprites;

    public Image SwitchesTimer;
    public float TimeBetweenSwitchSprites = 10;
    private float TimerSwitchs;

    public TakeItems Player;

    private void Start()
    {
        SwitchSprite();
        SwitchesTimer.fillAmount = TimeBetweenSwitchSprites;
    }

    private void Update()
    {
        if (TimerSwitchs >= 0)
        {
            TimerSwitchs -= Time.deltaTime;
            SwitchesTimer.fillAmount = TimerSwitchs / TimeBetweenSwitchSprites;
        }

        else
        {
            SwitchSprite();
        }
    }

    public void SwitchSprite()
    {
        PodiumEnemy.sprite = EnemieSprites[Random.Range(0, EnemieSprites.Length)];
        Player.SwitchPodiumSprite(PodiumEnemy.sprite);
        TimerSwitchs = TimeBetweenSwitchSprites;
    }
}
