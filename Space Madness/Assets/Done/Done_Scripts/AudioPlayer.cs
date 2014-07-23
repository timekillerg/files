using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip music_bg_meteor;
    public AudioClip music_bg_ice;
    public AudioClip music_bg_down;
    public AudioClip music_bg_sun;
    public AudioClip music_bg_fast_game;

    void Start()
    {
        if (AppCore.CurrentStatus != AppCore.Status.FAST_GAME)
        {            
            switch (GameCore.mapType)
            {
                case Maps.IceAnomaly:
                    this.audio.clip = music_bg_ice;
                    break;
                case Maps.MeteorRain:
                    this.audio.clip = music_bg_meteor;
                    break;
                case Maps.SunStorm:
                    this.audio.clip = music_bg_sun;
                    break;
                case Maps.DownFall:
                    this.audio.clip = music_bg_down;
                    break;
            }
        }
        else
            this.audio.clip = music_bg_fast_game;
        this.audio.mute = false;
        this.audio.Play();
    }
}
