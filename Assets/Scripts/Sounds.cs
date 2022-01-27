using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip GameStartSound;
    public AudioClip GameOverSound;
    public AudioClip LoseBallSound;
    public static Sounds Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayStart()
    {
        audioSource.PlayOneShot(GameStartSound);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(GameOverSound);
    }

    public void PlayLoseBall()
    {
        audioSource.PlayOneShot(LoseBallSound);
    }
}
