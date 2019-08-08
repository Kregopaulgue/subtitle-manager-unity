using System;
using UnityEngine;
using UnityEngine.UI;


public class SubtitleGuiManager : MonoBehaviour {

    public static SubtitleGuiManager instance = null;

    public Text textBox;

    public Color SubtitleColor
    {
        get
        {
            return this.textBox.color;
        }
        set
        {
            this.textBox.color = value;
        }
    }

    public static SubtitleGuiManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.Find("Game").transform.gameObject.
                    AddComponent<SubtitleGuiManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
  
    }

    public void InitializeSubtitleGuiManager()
    {
        this.textBox = FindObjectOfType<Text>();
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
        if(textBox.enabled)
        {
            textBox.enabled = false;
        } else
        {
            textBox.enabled = true;
        }
    }

}
