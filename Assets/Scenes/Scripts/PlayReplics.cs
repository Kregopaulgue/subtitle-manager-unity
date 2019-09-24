using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayReplics : MonoBehaviour {

    private List<string> clips;
    private AudioSource audioSource;
    private SubtitleView subtitleView;

    void Start () {
        audioSource = FindObjectOfType<AudioSource>();
        subtitleView = gameObject.GetComponent<SubtitleView>();

        SubtitleManager.Instance.InitializeSubtitleManager(this.subtitleView.resourceFile);
        subtitleView.createSubtitleBox();

        StartCoroutine(PlayAudio());
    }

    private IEnumerator PlayAudio()
    {
        Debug.Log("Started");
        audioSource.clip = (AudioClip)Resources.Load("voice_for_subtitles_1", typeof(AudioClip));
        audioSource.Play();
        SubtitleManager.Instance.Show(audioSource.clip, this.subtitleView);
        yield return new WaitForSeconds(audioSource.clip.length);
        Debug.Log("Played");

        audioSource.clip = (AudioClip)Resources.Load("voice_for_subtitles_2", typeof(AudioClip));
        audioSource.Play();
        SubtitleManager.Instance.Show(audioSource.clip,this.subtitleView);
        yield return new WaitForSeconds(audioSource.clip.length);

        audioSource.clip = (AudioClip)Resources.Load("voice_for_subtitles_3", typeof(AudioClip));
        audioSource.Play();
        SubtitleManager.Instance.Show(audioSource.clip,this.subtitleView);
        yield return new WaitForSeconds(audioSource.clip.length);

        audioSource.clip = (AudioClip)Resources.Load("voice_for_subtitles_4", typeof(AudioClip));
        audioSource.Play();
        SubtitleManager.Instance.Show(audioSource.clip,this.subtitleView);
        yield return new WaitForSeconds(audioSource.clip.length);

        audioSource.clip = (AudioClip)Resources.Load("voice_for_subtitles_5", typeof(AudioClip));
        audioSource.Play();
        SubtitleManager.Instance.Show(audioSource.clip, this.subtitleView);
        yield return new WaitForSeconds(audioSource.clip.length);
    }

}
