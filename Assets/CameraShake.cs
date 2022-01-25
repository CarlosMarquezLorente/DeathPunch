using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void ShakeCamera(float strenght, float duration)
    {
        StartCoroutine(CrShake(strenght, duration));
    }

    IEnumerator CrShake(float strenght, float duration)
    {

        float currentTime = 0;
        Vector3 startPos = transform.localPosition;

        while (currentTime < duration)
        {
            transform.localPosition = new Vector3(startPos.x + Random.Range(0, strenght), startPos.y + Random.Range(0, strenght),-10);
            yield return null;
            currentTime += Time.deltaTime;
        }
        transform.localPosition = startPos;
    }
  
}
