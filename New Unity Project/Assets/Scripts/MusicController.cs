using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    [Serializable]
    public class MusicTrigger
    {
        public AudioSource music;
        public bool trigger;
        [Range(0,1)]
        public float volume;
    }
    Animator _animator;
    [SerializeField] List<MusicTrigger> _audioSource;
    bool _isOurWorld;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        //_animator.SetTrigger("ToReal");
        //_audioSource.Play();        
       
    }
   
    
    void ToState(int i)
    {
        foreach (var item in _audioSource)
        {
            item.trigger = false;
        }
        _audioSource[i].trigger = true;
    }
    void Update()
    {
        /*
       if (_isOurWorld == true && !GWorld.IsOurWorld() == false)
        {
            ToState(3);
        }
        if (_isOurWorld == false && !GWorld.IsOurWorld() == true)
        {
            ToState(2);
        }*/
        if (_isOurWorld == true && !GWorld.IsOurWorld() == true && !_audioSource[2].music.isPlaying)
        {
            ToState(0);
        }
        if (_isOurWorld == false && !GWorld.IsOurWorld() == false && !_audioSource[3].music.isPlaying)
        {
            ToState(1);
        }
        _isOurWorld = !GWorld.IsOurWorld();
        MusicUpdate();

    }
    void MusicUpdate()
    {
        foreach (var item in _audioSource)
        {
            if (item.trigger)
            {
                item.music.volume = item.volume;
                if (!item.music.isPlaying)
                {
                    item.music.Play();
                }

            }
            else
            {
                item.music.Stop();
                
            }
        }
    }
}
