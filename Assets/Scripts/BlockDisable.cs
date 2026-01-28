using UnityEngine;
using System.Collections;

public class BlockDisable : MonoBehaviour
{
     MeshRenderer meshRenderer;
    Collider col;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        StartCoroutine(ToggleRoutine());
    }

    IEnumerator ToggleRoutine()
    {
        while (true)
        {
            EnableObstacle();
            yield return new WaitForSeconds(2f);

            DisableObstacle();
            yield return new WaitForSeconds(3f);
        }
    }

    void EnableObstacle()
    {
        meshRenderer.enabled = true;
        col.enabled = true;
    }

    void DisableObstacle()
    {
        meshRenderer.enabled = false;
        col.enabled = false;
    }
}
