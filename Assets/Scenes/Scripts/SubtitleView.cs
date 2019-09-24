using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleView : MonoBehaviour {

    private static SubtitleView instance = null;

    private Text topTextBox;
    private Text bottomTextBox;

    public Color topTextColor;
    public Color bottomTextColor;

    public int topTextFontSize;
    public int bottomTextFontSize;

    public static SubtitleView Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("Game").transform.gameObject.
                    AddComponent<SubtitleView>();
            }
            return instance;
        }
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            SubtitleView.Instance.InitializeSubtitleView();
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

    }

    public void InitializeSubtitleView()
    {
        Canvas canvasObject = FindObjectOfType<Canvas>();

        GameObject topSubtitleTextBox = new GameObject("Subtitle Text");
        topSubtitleTextBox.transform.SetParent(canvasObject.transform);

        GameObject bottomSubtitleTextBox = new GameObject("Subtitle Text");
        bottomSubtitleTextBox.transform.SetParent(canvasObject.transform);

        this.topTextBox = topSubtitleTextBox.AddComponent<Text>();

        this.topTextBox.color = this.topTextColor;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        this.topTextBox.font = ArialFont;
        this.topTextBox.material = ArialFont.material;
        this.topTextBox.alignment = TextAnchor.MiddleCenter;
        this.topTextBox.fontSize = this.topTextFontSize;
        this.topTextBox.enabled = true;

        this.bottomTextBox = bottomSubtitleTextBox.AddComponent<Text>();

        this.bottomTextBox.color = this.bottomTextColor;

        this.bottomTextBox.font = ArialFont;
        this.bottomTextBox.material = ArialFont.material;
        this.bottomTextBox.alignment = TextAnchor.MiddleCenter;
        this.bottomTextBox.fontSize = this.bottomTextFontSize;
        this.bottomTextBox.enabled = true;

        RectTransform canvasTransform = canvasObject.GetComponent<RectTransform>();

        RectTransform topSubtitleTransform = topSubtitleTextBox.GetComponent<RectTransform>();
        RectTransform bottomSubtitleTransform = bottomSubtitleTextBox.GetComponent<RectTransform>();

        topSubtitleTransform.anchoredPosition = new Vector2(0f, canvasTransform.rect.height * 0.6f);
        bottomSubtitleTransform.anchoredPosition = new Vector2(0f, -canvasTransform.rect.height * 0.6f);

        topSubtitleTransform.sizeDelta = new Vector2(canvasTransform.rect.width * 0.9f, canvasTransform.rect.height / 9);
        bottomSubtitleTransform.sizeDelta = new Vector2(canvasTransform.rect.width * 0.9f, canvasTransform.rect.height / 9);
    }

    public string TopSubtitleText
    {
        get
        {
            return this.topTextBox.text;
        }

        set
        {
            this.topTextBox.text = value;
        }
    }

    public string BottomSubtitleText
    {
        get
        {
            return this.bottomTextBox.text;
        }

        set
        {
            this.bottomTextBox.text = value;
        }
    }

    public Color TopSubtitleColor
    {
        get
        {
            return this.topTextBox.color;
        }

        set
        {
            this.topTextBox.color = value;
        }
    }

    public Color BottomSubtitleColor
    {
        get
        {
            return this.bottomTextBox.color;
        }

        set
        {
            this.bottomTextBox.color = value;
        }
    }

    public void SetTopSubtitleFontSize(int fontSize)
    {
        topTextBox.fontSize = fontSize;
    }

    public void SetBottomSubtitleFontSize(int fontSize)
    {
        topTextBox.fontSize = fontSize;
    }

    public void TurnSubtitles()
    {
        if (topTextBox.enabled)
        {
            topTextBox.enabled = false;
        }
        else
        {
            topTextBox.enabled = true;
        }

        if (bottomTextBox.enabled)
        {
            bottomTextBox.enabled = false;
        }
        else
        {
            bottomTextBox.enabled = true;
        }
    }
}
