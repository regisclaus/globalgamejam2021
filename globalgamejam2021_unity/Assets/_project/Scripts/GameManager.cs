using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float velocity = -5.0f;

    [SerializeField] public float velocityInc = -0.5f;

    [SerializeField] public float timeToInc = 5.0f;
    
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    private void IncVelocity() {
        velocity += velocityInc;
    }

    private void Start() {

        // Setar Alma
        PlayerPrefs.SetInt("soulColor", 2);
        PlayerChangeSoul pcs = FindObjectOfType<PlayerChangeSoul>();
        int soulColorInt = PlayerPrefs.GetInt("soulColor");
        if(soulColorInt >= 0) {
            pcs?.SetSoulColor((SoulColor)soulColorInt);
        }

        InvokeRepeating("IncVelocity", timeToInc, timeToInc);

    }

    public void LoseGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
