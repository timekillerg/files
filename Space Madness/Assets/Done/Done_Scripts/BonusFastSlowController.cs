using UnityEngine;
using AssemblyCSharp;
using System.Collections;

public class BonusFastSlowController : MonoBehaviour
{
    public GameObject SlowMotionBonus;
    public GameObject FastMotionBonus;
    public float BonusLifeTime;

    void Update()
    {
        if (AppCore.IsFastMotion)
        {
            Destroy(GameObject.FindGameObjectWithTag("slowModeBonus"));
            if (GameObject.FindGameObjectsWithTag("fastModeBonus").Length == 0)
            {
                GameObject fastMotionBonus = (GameObject)Instantiate(FastMotionBonus, transform.position, transform.rotation);
                fastMotionBonus.transform.parent = transform;
                StartCoroutine(WaitAndPrint(BonusLifeTime, true));
            }
        }
        else if (AppCore.IsSlowMotion)
        {
            Destroy(GameObject.FindGameObjectWithTag("fastModeBonus"));
            if (GameObject.FindGameObjectsWithTag("slowModeBonus").Length == 0)
            {
                GameObject slowMotionBonus = (GameObject)Instantiate(SlowMotionBonus, transform.position, transform.rotation);
                slowMotionBonus.transform.parent = transform;
                StartCoroutine(WaitAndPrint(BonusLifeTime,false));
            }
        }
    }

    IEnumerator WaitAndPrint(float waitTime, bool isFast)
    {
        yield return new WaitForSeconds(waitTime);
        if (isFast && AppCore.IsFastMotion)
        {
            AppCore.IsFastMotion = false;
            Destroy(GameObject.FindGameObjectWithTag("fastModeBonus"));
        }
        if (!isFast && AppCore.IsSlowMotion)
        {
            AppCore.IsSlowMotion = false;
            Destroy(GameObject.FindGameObjectWithTag("slowModeBonus"));
        }
    }
}


