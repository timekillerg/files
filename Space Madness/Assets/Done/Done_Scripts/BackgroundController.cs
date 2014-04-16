using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class BackgroundController : MonoBehaviour {
    public Texture fastGameBackground;
    public Texture meteorRainBackground;
    public Texture iceAnomalyBackground;
    public Texture sunStormBackground;
    public Texture downFallBackground;

    void Start()
    {
        ChangeBackround();
    }

    private void ChangeBackround()
    {
        if (AppCore.GetCurrentStatus() == AppCore.Status.FAST_GAME)
        {
            this.renderer.material.mainTexture = fastGameBackground;
        }
        else if (AppCore.GetCurrentStatus() == AppCore.Status.ANY_LEVEL)
        {
            switch (GameCore.mapType)
            {
                case (Maps.MeteorRain):
                    this.renderer.material.mainTexture = meteorRainBackground;
                    break;
                case (Maps.IceAnomaly):
                    this.renderer.material.mainTexture = iceAnomalyBackground;
                    break;
                case (Maps.SunStorm):
                    this.renderer.material.mainTexture = sunStormBackground;
                    break;
                case (Maps.DownFall):
                    this.renderer.material.mainTexture = downFallBackground;
                    break;
            }
        }
        else
        {
            this.renderer.material.mainTexture = fastGameBackground;
        }
    }
}