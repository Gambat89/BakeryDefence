using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager instance;

    public int attack = 0;
    public int defence = 0;
    public int speed = 0;
    public int health = 0;
    public int money = 0;
    public int magnet = 0;
    public int projectile = 0;
    public int mental = 0;
    public int power = 0;
    public int shield = 0;

    public TextMeshProUGUI abilityText;
    public Image abilityImage;
    public List<Button> abilityBtn;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AbilityUpdate();
    }

    public void AbilityUpdate()
    {
        abilityText.text = string.Format("Attack +{0}\n Defence +{1}\n Speed +{2}\n Health +{3}\n Money +{4}\n Magnet +{5}\n Projectile +{6}\n Mental +{7}\n Power +{8}\n Shield +{9}\n", 
                                        attack, defence, speed, health, money, magnet, projectile, mental, power, shield);
    }
}
