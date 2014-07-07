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

    public int howOftenBonusesDropping;

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
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Bonus"))
            return;

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            if (this.name.StartsWith("Done_Enemy Ship"))
            {
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    int bonus_id = UnityEngine.Random.Range(0, bonuses.Length);
                    if (bonus_id != 7)
                        Instantiate(bonuses[bonus_id], transform.position, Quaternion.identity);
                    else
                    {
                        if(1 == UnityEngine.Random.Range(0, 10))
                             Instantiate(bonuses[bonus_id], transform.position, Quaternion.identity);
                    }
                }
                GameCore.CountForMultiplicator++;
                if (GameCore.CountForMultiplicator % 3 >= 1)
                    GameCore.Multiplicator = GameCore.Multiplicator + GameCore.CountForMultiplicator / 3;
            }
        }

        if (other.CompareTag("Player") && !AppCore.IsGodMod)
        {
            GameCore.LifeCount--;
            if (GameCore.LifeCount == 0)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
                    AppCore.CurrentStatus = AppCore.Status.FAST_GAME_OVER;
                else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
                    AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL_FAILED;
            }
        }

        GameCore.Score = GameCore.Score + scoreValue * GameCore.Multiplicator;

        if (!other.gameObject.CompareTag("shield"))
            Destroy(other.gameObject);

        Destroy(gameObject);
    }
}