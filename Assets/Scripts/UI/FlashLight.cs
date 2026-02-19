using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [SerializeField] Image panelLight;
    private float alphaMin = 0;
    [Header("Flicker Paramiter")]
    [SerializeField]private float minDuration;
    [SerializeField]private float maxDuration;
    [SerializeField ]private float alphaMax;
    private Color panelColor;
    private float alphaPanel;

    private void Awake()
    {
        
        
    }

    private void Start()
    {
        panelColor = panelLight.color;

        alphaPanel = panelColor.a;

        StartCoroutine(FlashLighting());
        
        
    }

    

    IEnumerator FlashLighting()
    {
        while (true)
        {
            float startAlpha = alphaPanel;
            float endAlpha = Random.Range(alphaMin, alphaMax);
            float duration = Random.Range(minDuration, maxDuration);
            float time = 0;
            Debug.Log("primo while");
            while (time < duration)
            {
                time += Time.deltaTime;
                float alpha;
                alpha = Mathf.Lerp(startAlpha, endAlpha, time/duration);
                Color panelColor = panelLight.color;
                panelColor.a = alpha;
                panelLight.color = panelColor;
                yield return null;
                
            }
            
        }
    }
}
