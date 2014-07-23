using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;

public class SmokeAndFireController : MonoBehaviour
{
    public GameObject Smoke;
    public GameObject Fire1;
    public GameObject Fire2;

    void Start()
    {
        Smoke.SetActive(false);
        Fire1.SetActive(false);
        Fire2.SetActive(false);
    }

    void Update()
    {
        if (GameCore.Health < 30)
        {
            Smoke.SetActive(true);
            Fire1.SetActive(true);
            Fire2.SetActive(true);
        }
        else if (GameCore.Health <= 50)
        {
            Smoke.SetActive(true);
            Fire1.SetActive(true);
            Fire2.SetActive(false);
        }
        else if (GameCore.Health <= 80)
        {
            Smoke.SetActive(true);
            Fire1.SetActive(false);
            Fire2.SetActive(false);
        }
        else
        {
            Fire1.SetActive(false);
            Fire2.SetActive(false);
            Smoke.SetActive(false);
        }

    }
}

