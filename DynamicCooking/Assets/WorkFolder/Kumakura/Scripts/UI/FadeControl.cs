using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour
{

    public static FadeControl Instance = null;
    [SerializeField] private float fadeSpeed = 1.0f;
    [SerializeField] private Image fadeImage = null;

    Color myColor;
    Color color_zero;

    float alpha = 0;

    System.Action _callback;

    private void Awake()
    {
        myColor = fadeImage.color;
        color_zero = new Color(myColor.r, myColor.g, myColor.b, 0);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    IEnumerator FadeIn()
    {
        alpha = fadeImage.color.a;
        while (0 < alpha)
        {
            fadeImage.color = new Color(myColor.r, myColor.g, myColor.b, alpha);
            alpha -= Time.deltaTime / fadeSpeed;
            yield return null;
        }
        if (_callback != null) _callback();
        yield break;
    }

    IEnumerator FadeOut()
    {
        alpha = fadeImage.color.a;
        while (alpha < 1)
        {
            fadeImage.color = new Color(myColor.r, myColor.g, myColor.b, alpha);
            alpha += Time.deltaTime / fadeSpeed;
            yield return null;
        }
        if (_callback != null) _callback();
        yield break;
    }

    public void Fade(string name, System.Action callback = null)
    {
        _callback = callback;
        if (name == "in")
        {
            //黒フェードイン
            StartCoroutine(FadeIn());
        }
        else if (name == "out")
        {
            //黒フェードアウト
            StartCoroutine(FadeOut());
        }
    }
}
