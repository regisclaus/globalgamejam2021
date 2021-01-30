using UnityEngine;
using System;

public class PlayerChangeSoul : MonoBehaviour
{

    [SerializeField] public SoulColor soulColor;

    [SerializeField] private Color[] soulLightColors;
    [SerializeField] private Light soulLight;

    public void SetSoulColor(SoulColor soulColor) {
        this.soulColor = soulColor;

        // Cor da luz interna
        soulLight.color = soulLightColors[(int)soulColor];

        // Teste
        Debug.Log("Alma alterada: " + soulColor);
    }
}
