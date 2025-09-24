using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] [Min(0)] public int level = 0;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] [Min(1)] private int basePointsGoal = 32;
    [SerializeField] [Min(0)] private int points = 0;
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] [Min(1)] private int maxHealth = 100;
    [SerializeField] [Min(0)] private int health;
    [SerializeField] private Image healthImage;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject sliderVolume;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider soundSlider;
    private int goalpoints =>  basePointsGoal * (int) Math.Pow(2, level);

    void Start()
    {
        health = maxHealth;
        pointsText.text = "Points : " + points + " / " + goalpoints;
        audioMixer.GetFloat("MaterVolume", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;
    }

    public void AddPoint(int addpoint)
    {
        if (addpoint >= 0)
        {
            points += addpoint;

            if (points >= goalpoints)
            {
                winPanel.SetActive(true);
                level++;
                levelText.text = "Level : " + level;
            }
            pointsText.text = "Points : " + points + " / " + goalpoints;
        }
        else
        {
            health += addpoint;
            if (health <= 0)
            {
                health = 0;
                losePanel.SetActive(true);
            }
            healthImage.fillAmount = health / (float)maxHealth;
        }
    }

    public void Restart()
    {
        level = 0;
        points = 0;
        health = maxHealth;
        levelText.text = "Level : " + level;
        pointsText.text = "Points : " + points + " / " + goalpoints;
        healthImage.fillAmount = health / (float)maxHealth;
    }

    public void SwitchEnableSliderVolume()
    {
        sliderVolume.SetActive(!sliderVolume.activeSelf);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MaterVolume", volume);
    }

}
