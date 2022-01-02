using System.Collections;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    public void StartBlink()
    {
        StartCoroutine(Blinkeffect());
    }

    private IEnumerator Blinkeffect()
    {
        for (float t = 0f; t < 1f; t += Time.deltaTime)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                for (int j = 0; j < _renderers[i].materials.Length; j++)
                {
                    _renderers[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30f) * 0.5f + 0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }
    }
}
