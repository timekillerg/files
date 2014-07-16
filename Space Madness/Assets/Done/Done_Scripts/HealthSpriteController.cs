using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;

public class HealthSpriteController : MonoBehaviour
{
    public Sprite[] HealthSprites;
    private string Health;

    void Start()
    {
    }

    void Update()
    {
        Health = GameCore.Health.ToString();

        if (((SpriteRenderer)renderer).sprite.name != Health)
        {
            var sprites = HealthSprites.Where(s => s.name == Health).ToList();
            if (sprites.Any())
                ((SpriteRenderer)renderer).sprite = sprites.First();
        }
    }
}