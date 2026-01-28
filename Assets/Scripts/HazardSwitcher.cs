using UnityEngine;
using System.Collections;

public class HazardSwitcher : MonoBehaviour
{
    public GameObject blackCube;
    public GameObject redCube;

    void Start()
    {
        blackCube.SetActive(true);
        redCube.SetActive(false);

        StartCoroutine(SwitchRoutine());
    }

    IEnumerator SwitchRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);

            bool blackActive = blackCube.activeSelf;

            blackCube.SetActive(!blackActive);
            redCube.SetActive(blackActive);
        }
    }
}
