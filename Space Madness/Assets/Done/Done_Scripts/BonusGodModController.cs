using UnityEngine;
using AssemblyCSharp;
using System.Collections;

public class BonusGodModController : MonoBehaviour
{
    public GameObject GodModGuard;
    public float GodModLifeTime;
    
    void Update()
    {
        if (AppCore.IsGodMod)
            if (GameObject.FindGameObjectsWithTag("shield").Length == 0)
            {
                GameObject bonusGuard = (GameObject)Instantiate(GodModGuard, transform.position, transform.rotation);
                bonusGuard.transform.parent = transform;
                StartCoroutine(WaitAndPrint(GodModLifeTime));
            }
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        AppCore.IsGodMod = false;
        Destroy(GameObject.FindGameObjectWithTag("shield"));
    }
}
