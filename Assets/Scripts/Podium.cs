using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Podium : MonoBehaviour
{
    public SpriteRenderer PodiumEnemy;
    public List<Sprite> EnemieSprites;

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
        if(EnemieSprites.Count == 0)
        {
            Win();
            return;
        }
        PodiumEnemy.sprite = EnemieSprites[Random.Range(0, EnemieSprites.Count)];
        Player.SwitchPodiumSprite(PodiumEnemy.sprite);
        TimerSwitchs = TimeBetweenSwitchSprites;
    }

    public void Win()
    {
        //TODO smth after win
        print("Winnnnnnnnnnnner");
    }
}
