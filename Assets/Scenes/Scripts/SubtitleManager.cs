using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SubtitleManager : MonoBehaviour {

    private static SubtitleManager instance = null;

    public string resourceFile = "new_subtitles";

    private Dictionary<string, SubtitleLine> lines = new Dictionary<string, SubtitleLine>();
    private float clipTime = 0;
    private bool isDisplaying = false;

    public static SubtitleManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.Find("Game").transform.gameObject.
                    AddComponent<SubtitleManager>();
            }
            return instance;
        }
    }


    class SubtitleLine
    {
        public string CharacterName { get; set; }
        public string TextLine { get; set; }

        public SubtitleLine(string characterName, string textLine)
        {
            this.CharacterName = characterName;
            this.TextLine = textLine;
        }
    }


    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
        }
        else if(instance == this)
        {
            Destroy(gameObject);
        }

    }

    public void InitializeSubtitleManager()
    {
        var textAsset = Resources.Load<TextAsset>(resourceFile);
        var voiceOverText = JsonUtility.FromJson<VoiceOverText>(textAsset.text);

        foreach (var t in voiceOverText.replics)
        {
            lines[t.key] = new SubtitleLine(t.name, t.line);
        }
    }

    public string GetText(string textKey)
    {
        SubtitleLine tmp;

        if (lines.TryGetValue(textKey, out tmp))
            return tmp.CharacterName + " " + tmp.TextLine;

        return "<color=#ff00ff>MISSING TEXT FOR '" + textKey + "'</color>";
    }

    public void Show(AudioClip clip, SubtitleView subtitleView)
    {
        this.isDisplaying = true;

        if (this.clipTime <= 0)
        {
            StartCoroutine(ClearSubtitle());
        }

        var script = GetText(clip.name);
        subtitleView.SetText(script);

        this.clipTime = clip.length + 5f;
    }

    private IEnumerator ClearSubtitle()
    {      
        while(this.isDisplaying)
        {
            yield return new WaitForSeconds(0.5f);
            this.clipTime -= 0.5f;
            
            if(this.clipTime <= 0)
            {
                this.isDisplaying = false;
                SubtitleGuiManager.Instance.SetText(string.Empty);
            }
        }
    }
}
