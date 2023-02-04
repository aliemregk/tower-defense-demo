using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fade()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        Time.timeScale = 1;
        float time = 1.5f;

        while (time > 0f)
        {
            time -= Time.deltaTime;
            float a = curve.Evaluate(time);
            img.color = new Color(0f, 0f, 0f, a);

            yield return 0;
        }
    }
    IEnumerator FadeOut()
    {
        Time.timeScale = 1;
        float time = 0f;

        while (time < 2f)
        {
            time += Time.deltaTime;
            float a = curve.Evaluate(time);
            img.color = new Color(0f, 0f, 0f, a);

            yield return 0;
        }
    }
}
