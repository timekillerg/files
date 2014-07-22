using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class Done_DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    public GameObject minus20;
    public GameObject minus10;
    public Vector3 minusInitalPosition;

    private Done_GameController gameController;

    public int howOftenBonusesDropping;

    public GameObject[] bonuses;

    private int CountOfShots = 1;

    void Start()
    {
        if (this.name.StartsWith("Asteroid_ice_0") || this.CompareTag("EnemyShip"))
            CountOfShots = 2;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("EnemyShip") || other.CompareTag("EnemyBolt") || other.CompareTag("Meteor") || other.CompareTag("Bonus"))
            return;

        if (explosion != null)
        {
            if ((this.CompareTag("Meteor") || this.CompareTag("EnemyShip")) && other.CompareTag("DefaultPlayerBolt"))
            {
                CountOfShots--;
                if (CountOfShots <= 0)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                    InstantiateBonus();
                }
            }
            else
            {
                Instantiate(explosion, transform.position, transform.rotation);
                InstantiateBonus();
            }            
        }

        if (other.CompareTag("Player") && !AppCore.IsGodMod)
        {
            if (this.CompareTag("Meteor") || this.CompareTag("EnemyShip"))
            {
                GameCore.Health = GameCore.Health - 20;
                Instantiate(minus20, minusInitalPosition, new Quaternion(0, 180, 0, 0));
            }
            if (this.CompareTag("EnemyBolt"))
            {
                GameCore.Health = GameCore.Health - 10;
                Instantiate(minus10, minusInitalPosition, new Quaternion(0, 180, 0, 0));
            }
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

        if ((this.CompareTag("Meteor") || this.CompareTag("EnemyShip")) && other.CompareTag("DefaultPlayerBolt"))
        {
            if (CountOfShots <= 0)
                Destroy(gameObject);
        }
        else
            Destroy(gameObject);

    }


    void InstantiateBonus()
    {
        if (this.CompareTag("EnemyShip"))
        {
            if (UnityEngine.Random.Range(0, howOftenBonusesDropping) == 0)
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
}