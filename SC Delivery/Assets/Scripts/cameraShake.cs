using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{

    //Efeito de Balanço da Camera;

    public IEnumerator Shake(float duracao, float forca)
    {
        Vector3 posOrigin = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duracao)
        {
            float x = Random.Range(-1f, 1f) * forca;
            float y = Random.Range(-1f, 1f) * forca;

            transform.position = new Vector3(posOrigin.x + x, posOrigin.y + y, posOrigin.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = posOrigin;
    }
}
