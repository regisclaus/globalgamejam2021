using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private float soulEnergy = 100f;
    [SerializeField] private float soulEnergyWhenChange = 20f;
    [SerializeField] private float soulEnergyRegenPerTime = 5f;
    [SerializeField] private float soulEnergyTime = 1f;

    [SerializeField] private Image soulBar;



    [SerializeField] private float bodyEnergy = 20f;
    [SerializeField] private float bodyEnergyPerTime = 1f;
    [SerializeField] private float bodyEnergyTime = 1f;

    private float bodyEnergyTotal;

    private float soulEnergyTotal;

    [SerializeField] private Image bodyBar;

    private void Start() {

        soulEnergyTotal = soulEnergy;

        bodyEnergyTotal = bodyEnergy;
        bodyBar.fillAmount = bodyEnergy / bodyEnergyTotal;
        InvokeRepeating("ConsumeBodyEnergy", bodyEnergyTime, bodyEnergyTime);

        InvokeRepeating("RegenSoulEmergy", soulEnergyTime, soulEnergyTime);
    }

    private void ConsumeBodyEnergy() {
        bodyEnergy -= bodyEnergyPerTime;

        bodyBar.fillAmount = bodyEnergy / bodyEnergyTotal;

        if(bodyEnergy <= 0) {
            GameManager.instance.LoseGame();
        }
    }

    public void RegenEnergyBody() {
        bodyEnergy = bodyEnergyTotal;
    }

    public void ConsumeSoulEnergy() {
        soulEnergy -= soulEnergyWhenChange;
        soulBar.fillAmount = soulEnergy / soulEnergyTotal;
        if(soulEnergy <= 0) {
            GameManager.instance.LoseGame();
        }
    }

    public void RegenSoulEmergy() {
        if(soulEnergy < soulEnergyTotal) {
            soulEnergy += soulEnergyRegenPerTime;
            soulBar.fillAmount = soulEnergy / soulEnergyTotal;
        }
    }


}
