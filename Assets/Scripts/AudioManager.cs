using System.Collections.Generic;
using UnityEngine;

// 简单的音频管理（从 Resources/Audio/ 加载音频）
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource bgmSource;
    private AudioSource sfxSource;
    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);

        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        sfxSource = gameObject.AddComponent<AudioSource>();

        // 尝试从 Resources/Audio 加载常用音效
        LoadClip("pickup");
        LoadClip("hit");
        LoadClip("bgm");
    }

    void LoadClip(string name)
    {
        AudioClip ac = Resources.Load<AudioClip>($"Audio/{name}");
        if (ac != null) clips[name] = ac;
    }

    public void PlayBGM()
    {
        if (clips.TryGetValue("bgm", out var clip))
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        if (clips.TryGetValue(name, out var clip))
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
