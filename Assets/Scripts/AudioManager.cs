using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource EffectAudioSource;

    [SerializeField] private AudioClip BackGroundClip;
    [SerializeField] private AudioClip JumpClip;
    [SerializeField] private AudioClip CoinClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackgroundMusic()
    {
        backgroundAudioSource.clip = BackGroundClip;
        backgroundAudioSource.Play();
    }
}
