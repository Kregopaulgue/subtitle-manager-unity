using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleView : MonoBehaviour {

    public string resourceFile;

    public Color color = Color.black;

    public float height;
    public float width;

    public float textBoxCoordinateX;
    public float textBoxCoordinateY;

    private float canvasHeight;
    private float canvasWidth;

    private Text textBox;

    // Use this for initialization
    void Awake() {
        Canvas canvasObject = FindObjectOfType<Canvas>();
        RectTransform canvasTransform = canvasObject.GetComponent<RectTransform>();

        this.canvasHeight = canvasTransform.rect.height;
        this.canvasWidth = canvasTransform.rect.width;
    }

    public void createSubtitleBox()
    {
        Canvas canvasObject = FindObjectOfType<Canvas>();

        GameObject subtitleTextBox = new GameObject("Subtitle Text");
        subtitleTextBox.transform.SetParent(canvasObject.transform);

        this.setUpSubtitleText(subtitleTextBox);
        this.setSubtitlePosition(subtitleTextBox);
    }

    private void setUpSubtitleText(GameObject subtitleTextBox)
    {
        this.textBox = subtitleTextBox.AddComponent<Text>();

        this.textBox.color = this.color;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        this.textBox.font = ArialFont;
        this.textBox.material = ArialFont.material;
        this.textBox.alignment = TextAnchor.MiddleCenter;
        this.textBox.enabled = true;
    }

    private void setSubtitlePosition(GameObject subtitleTextBox)
    {
        RectTransform subtitleTransform = subtitleTextBox.GetComponent<RectTransform>();

        if (this.textBoxCoordinateX == 0 && this.textBoxCoordinateY == 0)
        {
            subtitleTransform.anchoredPosition = new Vector2(0f, -this.canvasHeight * 0.45f);
        }
        else
        {
            subtitleTransform.anchoredPosition = new Vector2(this.textBoxCoordinateX, this.textBoxCoordinateY);
        }

        if (this.width == 0 && this.height == 0)
        {
            subtitleTransform.sizeDelta = new Vector2(this.canvasWidth * 0.9f, this.canvasHeight / 9);
        }
        else
        {
            subtitleTransform.sizeDelta = new Vector2(this.width, this.height);
        }
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
