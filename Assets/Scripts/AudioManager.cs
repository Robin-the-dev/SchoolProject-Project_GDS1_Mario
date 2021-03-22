using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Just call the functions here when needed
 *
 * To use a function use this function in any script where play jump small is the audio being played
 * AudioManager.Instance.PlayJumpSmall();
 */
public class AudioManager : MonoBehaviour
{
    //Singleton to create an instance of AudioManager that every script has access to
    //Makes it so you don't need a reference to AudioManager on each script that uses it
    #region Singleton
    private static AudioManager _instance; 
    public static AudioManager Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    #endregion

    //Variables for audio sources
    [Header("Audio Sources")] 
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioSource SFXSource;

    //Variables for SFX clips
    [Header("SFX Clips")] 
    [SerializeField] private AudioClip oneUp;
    [SerializeField] private AudioClip breakBlock, bump, coin, fireball, fireworks, flagpole, gameOver, jump_small, jump_super, kick, marioDie, pause, pipeorpowerdown, powerup_eat, powerup_appear, stage_Clear, stomp;

    //Variables for BGM clips
    [Header("BGM Clips")] 
    [SerializeField] private AudioClip BGM_normal;
    [SerializeField] private AudioClip BGM_Speedup, BGM_underground, BGM_undergroundSpeedUp, BGM_star, BGM_Points;

    #region SFX

    //Each method plays its own AudioClip
    public void PlayOneUp()
    {
        PlaySFX(oneUp);
    }
    
    public void PlayBreakBlock()
    {
        PlaySFX(breakBlock);
    }
    
    public void PlayBump()
    {
        PlaySFX(bump);
    }
    
    public void PlayCoin()
    {
        PlaySFX(coin);
    }
    
    public void PlayFireball()
    {
        PlaySFX(fireball);
    }
    
    public void PlayFireworks()
    {
        PlaySFX(fireworks);
    }
    
    public void PlayFlagpole()
    {
        PlaySFX(flagpole);
    }
    
    public void PlayGameOver()
    {
        PlaySFX(gameOver);
    }
    
    public void PlayJumpSmall()
    {
        PlaySFX(jump_small);
    }
    
    public void PlayJump_super()
    {
        PlaySFX(jump_super);
    }
    
    public void PlayKick()
    {
        PlaySFX(kick);
    }
    
    public void PlayMarioDie()
    {
        PlaySFX(marioDie);
    }
    
    public void PlayPause()
    {
        PlaySFX(pause);
    }
    
    //Call this function when going into the pipe for suboorld ( optional )
    //Plays the pipe audio, pause then change to underground BGM
    public void PlayPipeGoingIn()
    {
        BGMSource.Stop();
        PlaySFX(pipeorpowerdown);
        BGMSource.clip = BGM_underground;
        BGMSource.PlayDelayed(pipeorpowerdown.length + 2);
    }
    
    //Call this function when going out of the pipe for subworld ( optional )
    //Plays pipe audio and BGM normal at the same time.
    public void PlayPipeGoingOut()
    {
        BGMSource.Stop();
        PlaySFX(pipeorpowerdown);
        BGMSource.clip = BGM_normal;
        BGMSource.Play();
    }
    
    public void PlayPowerDown()
    {
        PlaySFX(pipeorpowerdown);
    }
    
    public void PlayPowerup_eat()
    {
        PlaySFX(powerup_eat);
    }
    
    public void PlayPowerup_appear()
    {
        PlaySFX(powerup_appear);
    }
    
    public void PlayStage_Clear()
    {
        PlaySFX(stage_Clear);
    }
    
    public void PlayStomp()
    {
        PlaySFX(stomp);
    }

    #endregion functions

    #region BGM functions

    public void BGMNormal()
    {
        PlayBGM(BGM_normal);
    }
    
    public void BGMNormalSpeedUp()
    {
        PlayBGM(BGM_Speedup);
    }
    
    public void BGMUnderground()
    {
        PlayBGM(BGM_underground);
    }
    
    public void BGMUndergroundSpeedUp()
    {
        PlayBGM(BGM_undergroundSpeedUp);
    }
    
    public void BGMStar()
    {
        PlayStar();
    }

    #endregion

    //Call this function once Mario touches the flag. Does all the audio required for it
    public void PlayLevelClear()
    {
        BGMSource.Stop();
        SFXSource.Stop();
        SFXSource.PlayOneShot(flagpole);
        SFXSource.clip = stage_Clear;
        SFXSource.PlayDelayed(flagpole.length + 0.5f);
    }

    //Plays the audio for points
    public void PlayPoints()
    {
        PlayBGM(BGM_Points);
    }

    //Stops BGM. Mainly for when time bonus points have finished being added
    public void StopBGM()
    {
        BGMSource.Stop();
    }
    
    //Plays AudioClip that has been passed through
    private void PlaySFX(AudioClip sound)
    {
        //Stops any current sound effect and plays the sound being passed through
        SFXSource.Stop();
        SFXSource.clip = sound;
        SFXSource.Play();
    }
    
    //Changes BGM clip and plays it
    private void PlayBGM(AudioClip sound)
    {
        BGMSource.clip = sound;
        BGMSource.Play();
    }
    
    //Plays BGM audio for star and returns to map bgm after time runs out
    private void PlayStar()
    {
        BGMSource.Stop();
        BGMSource.PlayOneShot(BGM_star);
        BGMSource.PlayDelayed(BGM_star.length);
    }
}
