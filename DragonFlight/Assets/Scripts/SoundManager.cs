using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    AudioSource myAudio;

    public AudioClip SoundBullet;
    public AudioClip SoundDie;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(SoundBullet);
    }
    public void PlayDieSound()
    {
        myAudio.PlayOneShot(SoundDie);
    }

    void Update()
    {
        
    }
}
