using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField] AudioSource _musicPlayer;
    [SerializeField] AudioClip _phase1Music;
    [SerializeField] AudioClip _phase2Music;
    [SerializeField] AudioClip _phase3Music;
    [SerializeField] AudioClip _phase4Music;


    //hookup to see the BrotherDied event
    [SerializeField] private Health _healthA;
    [SerializeField] private Health _healthB;

    private void OnEnable()
    {
        if (_healthA != null) { _healthA.BrotherDied += OnBrotherDied; }
        if (_healthB != null) { _healthB.BrotherDied += OnBrotherDied; }

    }

    void Start()
    {
        Phase1();
    }


    public void OnBrotherDied()
    {
        Phase2();
    }

    void Phase1()
    {
        _musicPlayer.clip = _phase1Music;
        _musicPlayer.loop = true;
        _musicPlayer.Play();
    }
    void Phase2()
    {
        _musicPlayer.clip = _phase2Music;
        _musicPlayer.Play();
    }
    public void Phase3()
    {
        _musicPlayer.clip = _phase3Music;
        _musicPlayer.Play();
    }

    public void Phase4()
    {
        _musicPlayer.clip = _phase4Music;
        _musicPlayer.loop = false;
        _musicPlayer.Play();
    }
}
