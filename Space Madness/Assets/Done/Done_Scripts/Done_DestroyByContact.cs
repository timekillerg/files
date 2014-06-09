using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class Done_DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private Done_GameController gameController;

    public GameObject[] bonuses;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            if (this.name.StartsWith("Done_Enemy Ship"))
            {
                if (UnityEngine.Random.Range(0,3)==0)
                {
                    int bonus_id = UnityEngine.Random.Range(0, bonuses.Length);
                    UnityEngine.Object bonus = Instantiate(bonuses[bonus_id], transform.position, Quaternion.identity);
                }
            }
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        if (this.name.StartsWith("Done_Enemy Ship"))
        {
            GameCore.CountForMultiplicator++;
            if (GameCore.CountForMultiplicator % 3 == 0)
                GameCore.Multiplicator = 1 + GameCore.CountForMultiplicator / 3;
        }


        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}