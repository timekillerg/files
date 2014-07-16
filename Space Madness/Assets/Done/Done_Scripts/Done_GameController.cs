using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;

    public GameObject[] hazardsMeteor;
    public GameObject[] hazardsIce;
    public GameObject[] hazardsDownFall;
    public GameObject[] hazardsSunStorm;

    public GameObject countdown;
    public GameObject gameOverButtons;
    public GameObject menuPauseButtons;
    public GameObject levelCompleteButtons;
    public GameObject levelFailedButtons;

    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;

    public GUIText multiplicatorText;
    public GameObject multiplicatorTextBorder;

    private bool gameOver;
    private int score;

    private Vector3 V3_DELTA = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 V3_MULT_VISIBLE = new Vector3(-4.75f, 1.9f, 12.4f);
    private Vector3 V3_MULT_HIDDEN = new Vector3(-8f, 1.9f, 12.4f);

    private float speed = 5f;

    private void MoveAndStopStopAtPosition(GameObject go, Vector3 expectedPosition)
    {
        if (go != null)
        {
            go.rigidbody.velocity = Vector3.zero;
            go.rigidbody.transform.position = Vector3.Lerp(go.transform.position, expectedPosition, Time.fixedDeltaTime * speed);
            if (go.rigidbody.position.x >= (expectedPosition.x - V3_DELTA.x) && go.rigidbody.position.x <= (expectedPosition.x + V3_DELTA.x))
            {
                if (go.rigidbody.velocity == Vector3.zero)
                    return;
                else
                    go.rigidbody.velocity = Vector3.zero;
            }
        }
    }

    void Start()
    {
        hazards = hazardsMeteor;
        if (AppCore.CurrentStatus != AppCore.Status.FAST_GAME)
            if (GameCore.mapType == Maps.IceAnomaly)
                hazards = hazardsIce;
            else if (GameCore.mapType == Maps.SunStorm)
                hazards = hazardsSunStorm;
            else if (GameCore.mapType == Maps.MeteorRain)
                hazards = hazardsMeteor;
            else
                hazards = hazardsMeteor;
        Instantiate(countdown);
        gameOver = false;
        score = 0;
        StartCoroutine(SpawnWaves());
        AppCore.IsFastMotion = false;
        AppCore.IsGodMod = false;
        AppCore.IsSlowMotion = false;
        GameCore.Multiplicator = 1;
        GameCore.CountForMultiplicator = 0;
        GameCore.Score = 0;
        GameCore.LifeCount = 3;
        GameCore.Health = 100;
    }

    void ShowMultiplicatorIcon()
    {
        if (GameCore.Multiplicator > 1 && (AppCore.CurrentStatus == AppCore.Status.FAST_GAME || AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL || AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE || AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE))
        {
            MoveAndStopStopAtPosition(multiplicatorTextBorder, V3_MULT_VISIBLE);
            if (multiplicatorTextBorder.transform.position.x > -5)
                multiplicatorText.text = "X " + GameCore.Multiplicator.ToString();
        }
        else
        {
            if (multiplicatorText.text != " ")
                multiplicatorText.text = " ";
            MoveAndStopStopAtPosition(multiplicatorTextBorder, V3_MULT_HIDDEN);
        }
    }

    void Update()
    {
        ShowMultiplicatorIcon();
        CheckIsGameOver();
        CheckIsScoreChanged();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME)
            {
                Instantiate(menuPauseButtons);
                AppCore.CurrentStatus = AppCore.Status.FAST_GAME_PAUSE;
            }
            else if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_PAUSE)
            {
                AppCore.CurrentStatus = AppCore.Status.FAST_GAME;
                Instantiate(countdown);
            }
            else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
            {
                Instantiate(menuPauseButtons);
                AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL_PAUSE;
            }
            else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_PAUSE)
            {
                AppCore.CurrentStatus = AppCore.Status.ANY_LEVEL;
                Instantiate(countdown);
            }
            else if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_OVER)
            {
                AppCore.CurrentStatus = AppCore.Status.MENU;
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME || AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL)
                    Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                break;
            }
        }
    }


    void CheckIsScoreChanged()
    {
        if (scoreText.text != GameCore.Score.ToString())
            scoreText.text = GameCore.Score.ToString();
    }

    public void CheckIsGameOver()
    {
        if (AppCore.CurrentStatus == AppCore.Status.FAST_GAME_OVER && gameOver == false)
        {
            Instantiate(gameOverButtons);
            gameOver = true;
        }
        else if (AppCore.CurrentStatus == AppCore.Status.ANY_LEVEL_FAILED && gameOver == false)
        {
            Instantiate(levelFailedButtons);
            gameOver = true;
        }
    }
}