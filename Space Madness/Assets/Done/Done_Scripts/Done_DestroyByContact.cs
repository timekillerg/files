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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("EnemyShip") || other.CompareTag("EnemyBolt") || other.CompareTag("Meteor") || other.CompareTag("Bonus"))
            return;

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            if (this.CompareTag("EnemyShip"))
            {
                if (UnityEngine.Random.Range(0, 3) == 0)
                {
                    int bonus_id = UnityEngine.Random.Range(0, bonuses.Length);
                    if (bonus_id != 7)
                        Instantiate(bonuses[bonus_id], transform.position, Quaternion.identity);
                    else
                    {
                        if (1 == UnityEngine.Random.Range(0, howOftenBonusesDropping))
                            Instantiate(bonuses[bonus_id], transform.position, Quaternion.identity);
                    }
                }
                GameCore.CountForMultiplicator++;
                if (GameCore.CountForMultiplicator >= 3)
                    GameCore.Multiplicator = 1 + (GameCore.CountForMultiplicator / 3);
            }
        }

        if (other.CompareTag("Player") && !AppCore.IsGodMod)
        {
            if (this.CompareTag("Meteor") || this.CompareTag("EnemyShip"))
                GameCore.Health = GameCore.Health - 20;
            if (this.CompareTag("EnemyBolt"))
                GameCore.Health = GameCore.Health - 10;
            if (GameCore.Health < 0)
                GameCore.Health = 0;

            if (GameCore.Health == 0)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
                    AppCore.CurrentStatus = AppCore.Status.FAST_GAME_OVER;
                else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
                    AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL_FAILED;
            }
        }
        else if (!other.gameObject.CompareTag("shield"))
            Destroy(other.gameObject);

        GameCore.Score = GameCore.Score + scoreValue * GameCore.Multiplicator;

        Destroy(gameObject);
    }
}