using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource _source;

    public override void Awake()
    {
        base.Awake();
        _source = GetComponent<AudioSource>();
        
    }
    
    // Play a sound effect
    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip == null) return;

        if (_source == null) return;
        
        _source.clip = clip;
        _source.PlayOneShot(clip);
    }

    // Play a sound effect with a duration
    // This is useful for sounds that need to be looped
    public void PlayLoopedSound(AudioClip clip, float soundDuration, bool isLooped)
    {
        if (clip == null) return;

        if (_source == null) return;

        _source.clip = clip;
        _source.loop = isLooped;
        _source.Play();

        if (_source.isPlaying)
        {
            soundDuration -= Time.fixedDeltaTime;
            
            if (soundDuration <= 0f)
                _source.Stop();
        }
    }

    // Play music
    public void PlayMusic(AudioClip clip, GameObject sourceObject, bool isLooped)
    {
        if (clip == null)  return;

        AudioSource source = sourceObject.GetComponent<AudioSource>();

        if (source == null) return;

        _source.clip = clip;
        _source.loop = isLooped;
        _source.Play();
    }
}
