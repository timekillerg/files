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

    public GameObject bonusEffectAppear;
    public GameObject bonus;

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
                Instantiate(bonusEffectAppear, transform.position, transform.rotation);
                Instantiate(bonus, transform.position, Quaternion.identity);
                bonus.rigidbody.velocity = rigidbody.velocity;
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