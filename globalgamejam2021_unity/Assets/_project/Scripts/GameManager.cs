using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] public float velocity = -5.0f;

    [SerializeField] public float velocityInc = -0.5f;

    [SerializeField] public float timeToInc = 5.0f;

    [SerializeField] private GameObject gameOverModal;
    
    public static GameManager instance;

    private float initialTime;

    [SerializeField] private Text timeText;

    private void Awake() {
        instance = this;
    }

    private void IncVelocity() {
        velocity += velocityInc;
    }

    private void Start() {

        initialTime = Time.time;
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
        PlayerSounds.instance.GameOver();
        Time.timeScale = 0;
        gameOverModal.SetActive(true);
        timeText.text = ((int) (Time.time - initialTime)).ToString() + " seconds";
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void TitleScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}
