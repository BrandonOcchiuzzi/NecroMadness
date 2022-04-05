using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatText> floatTexts = new List<FloatText>();

    public void Update()
    {
        foreach (FloatText txt in floatTexts)
        txt.UpdateFloatText();
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatText floatText = GetFloatText();

        floatText.txt.text = msg;
        floatText.txt.fontSize = fontSize;
        floatText.txt.color = color;
        floatText.go.transform.position = Camera.main.WorldToScreenPoint (position);
        floatText.motion = motion;
        floatText.duration = duration;

        floatText.Show();
    }

    private FloatText GetFloatText()
    {
        FloatText txt = floatTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatTexts.Add(txt);
        }

        return txt;
    }    
}
