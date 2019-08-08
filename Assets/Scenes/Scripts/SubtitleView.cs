using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleView : MonoBehaviour {

    private Text textBox;
    public Color color = Color.black;

	// Use this for initialization
	void Start () {
        Canvas canvasObject = FindObjectOfType<Canvas>();

        GameObject subtitleTextBox = new GameObject("Subtitle Text");

        this.textBox = subtitleTextBox.AddComponent<Text>();

        this.textBox.color = this.color;

        Font ArialFont = (Font) Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        this.textBox.font = ArialFont;
        this.textBox.material = ArialFont.material;
        this.textBox.alignment = TextAnchor.MiddleCenter;
        this.textBox.enabled = true;

        subtitleTextBox.transform.SetParent(canvasObject.transform);
    }

    public void Clear()
    {
        textBox.text = string.Empty;
    }

    public void SetText(string text)
    {
        textBox.text = text;
    }

    public void SetFontSize(int fontSize)
    {
        textBox.fontSize = fontSize;
    }

    public void TurnSubtitles()
    {
        if (textBox.enabled)
        {
            textBox.enabled = false;
        }
        else
        {
            textBox.enabled = true;
        }
    }
}
