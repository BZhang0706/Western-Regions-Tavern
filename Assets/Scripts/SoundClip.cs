using UnityEngine;

[CreateAssetMenu(fileName = "NewSound", menuName = "Sound", order = 2)]
public class SoundClip : ScriptableObject
{
    public AudioClip clip;
    public bool loop;
    public float volume = 1f;
    //public bool fadeIn;
    //public bool fadeOut;
    //public float fadeInDuration = 1f;
    //public float fadeOutDuration = 1f;
}

