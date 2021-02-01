using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public static PlayerSounds instance;

    [SerializeField] private AudioClip changeSoul;

    [SerializeField] private AudioClip jump;

    [SerializeField] private AudioClip gameOver;

    private AudioSource audioSource;

    private void Awake() {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeSoul() {
        audioSource.PlayOneShot(changeSoul);
    }

    public void Jump() {
        audioSource.PlayOneShot(jump);
    }


    public void GameOver() {
        audioSource.PlayOneShot(gameOver);
    }
}
