using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {

        // Setar Alma
        PlayerPrefs.SetInt("soulColor", 2);
        PlayerChangeSoul pcs = FindObjectOfType<PlayerChangeSoul>();
        int soulColorInt = PlayerPrefs.GetInt("soulColor");
        if(soulColorInt >= 0) {
            pcs?.SetSoulColor((SoulColor)soulColorInt);
        }

    }
}
