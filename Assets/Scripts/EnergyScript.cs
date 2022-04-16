using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnergyScript : MonoBehaviour
{
    public static int minEnergy = 0;
    private static int maxEnergy = 5;

    public static int energy;

    private static float timeEnergyPlus = 180;
    private static float timeEnergyPr;

    [SerializeField] private Text energyText;
    [SerializeField] private Text timeText;

    TimeSpan dateTime = new TimeSpan(); 

    void Start()
    {
        GetEnergy();
        if(!PlayerPrefs.HasKey("Energy") && !PlayerPrefs.HasKey("Time"))
        {
            SetEnergy();
        }
    }

    void Update()
    {
        energyText.text = energy.ToString() + "/5";

        if(energy < 5)
        {
            dateTime = TimeSpan.FromSeconds(timeEnergyPr);
            timeText.text = dateTime.ToString().Replace(".", "");

            timeEnergyPr -= Time.deltaTime;
            if(timeEnergyPr <= 0)
            {
                energy++;
                timeEnergyPr = timeEnergyPlus;
            }
        }
        else
        {
            timeText.text = "00:00:00";
        }
    }

    public static void SetEnergy()
    {
        PlayerPrefs.SetInt("Energy", energy);
        PlayerPrefs.SetFloat("Time", timeEnergyPr);
    }

    public static void GetEnergy()
    {
        if (PlayerPrefs.HasKey("Energy"))
        {
            energy = PlayerPrefs.GetInt("Energy");
        }      
        else
        {
            energy = maxEnergy;
        }
        
        if(PlayerPrefs.HasKey("Time"))
        {
            timeEnergyPr = PlayerPrefs.GetFloat("Time");
        }
        else
        {
            timeEnergyPr = timeEnergyPlus;
        }
        
    }
}
